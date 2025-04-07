using System;

namespace LabWork
{
    class Line2D
    {
        protected double a0, a1, a2;

        public virtual void SetCoefficients(double a0, double a1, double a2)
        {
            this.a0 = a0;
            this.a1 = a1;
            this.a2 = a2;
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Коефіцієнти прямої: a0 = {a0}, a1 = {a1}, a2 = {a2}");
        }

        public virtual bool IsPointOnLine(double x, double y)
        {
            return Math.Abs(a1 * x + a2 * y + a0) < 0.0001;
        }
    }

    class Hyperplane4D : Line2D
    {
        private double a3, a4;

        public void SetCoefficients(double a0, double a1, double a2, double a3, double a4)
        {
            base.SetCoefficients(a0, a1, a2);
            this.a3 = a3;
            this.a4 = a4;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Коефіцієнти гіперплощини: a0 = {a0}, a1 = {a1}, a2 = {a2}, a3 = {a3}, a4 = {a4}");
        }

        public bool IsPointOnHyperplane(double x1, double x2, double x3, double x4)
        {
            return Math.Abs(a4 * x4 + a3 * x3 + a2 * x2 + a1 * x1 + a0) < 0.0001;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Line2D line = new Line2D();
            line.SetCoefficients(a0: -6, a1: 2, a2: 3);
            line.PrintCoefficients();

            Console.Write("Введіть точку (x y) для перевірки належності до прямої: ");
            string[] input2D = Console.ReadLine().Split();
            double x2d = double.Parse(input2D[0]);
            double y2d = double.Parse(input2D[1]);

            Console.WriteLine(line.IsPointOnLine(x2d, y2d)
                ? "Точка належить прямій."
                : "Точка не належить прямій.");


            Hyperplane4D hyper = new Hyperplane4D();
            hyper.SetCoefficients(a0: -10, a1: 1, a2: 2, a3: 3, a4: 4);
            hyper.PrintCoefficients();

            Console.Write("Введіть точку (x1 x2 x3 x4) для перевірки належності до гіперплощини: ");
            string[] input4D = Console.ReadLine().Split();
            double x1 = double.Parse(input4D[0]);
            double x2 = double.Parse(input4D[1]);
            double x3 = double.Parse(input4D[2]);
            double x4 = double.Parse(input4D[3]);

            Console.WriteLine(hyper.IsPointOnHyperplane(x1, x2, x3, x4)
                ? "Точка належить гіперплощині."
                : "Точка не належить гіперплощині.");
        }
    }
}
