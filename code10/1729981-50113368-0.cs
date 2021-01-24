    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Lesson02
    {
        class Rectangle
        {
            private double length; //default access level
            private double width;
            public Rectangle(double l, double w)
            {
                length = l;
                width = w;
            }
            public double GetArea()
            {
                return length * width;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Lesson02.Rectangle rect = new Lesson02.Rectangle(10.0, 20.0);
            double area = rect.GetArea();
            Console.WriteLine("Area of Rectangle: {0}", area);
        }
    }
