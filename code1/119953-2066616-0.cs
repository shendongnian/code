    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
    namespace PointDrawing
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Point> points = new List<Point>();
                points.Add(new Point(1, 1));
                points.Add(new Point(2, 2));
                points.Add(new Point(3, 3));
                points.Add(new Point(4, 4));
                points.Add(new Point(5, 5));
                points.Add(new Point(6, 6));
                points.Add(new Point(7, 7));
                if (points.Count > 0)
                {
                    Point src = points[0];
                    points.ForEach(p => Draw(ref src, p));
                }
            }
            public static void Draw(ref Point p1, Point p2)
            {
                if (p1 != p2)
                {
                    //Draw from p1 to p2 here
                }
    
                p1 = p2; //assign so that p2 is the next origin
            }
        }
    }
