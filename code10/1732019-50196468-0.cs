    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<Point>> points = new List<List<Point>>() {
                    new List<Point>() { new Point(0,0),new Point(0,1),new Point(0,2),},
                    new List<Point>() { new Point(1,0),new Point(1,1),new Point(1,2),},
                    new List<Point>() { new Point(2,0),new Point(2,1),new Point(2,2),},
                    new List<Point>() { new Point(3,0),new Point(3,1),new Point(3,2),}
                };
            }
        }
    }
