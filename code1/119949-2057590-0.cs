    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace overflow2
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
                points.Add(new Point(7, 7)); // odd number to test end
                foreach (LineSegment<Point> linesegment in points.GetPairs())
                    Console.WriteLine("From " + linesegment.Value1.ToString() + " to " + linesegment.Value2.ToString());
                Console.ReadLine();
            }
        }
        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public Point(int _x, int _y)
            {
                x = _x;
                y = _x;
            }
            public override string ToString()
            {
                return string.Format("{0},{1}", x, y);
            }
        }
        public class LineSegment<T>
        {
            public T Value1 { get; private set; }
            public T Value2 { get; private set; }
            public LineSegment(T value1, T value2)
            {
                Value1 = value1;
                Value2 = value2;
            }
        }
        public static class Util
        {
            public static List<LineSegment<Point>> GetPairs(this List<Point> points)
            {
                if (points.Count >= 2)
                {
                    var pair = new LineSegment<Point>(points.Take(1).First(), points.Skip(1).Take(1).First());
                    var res = new List<LineSegment<Point>>() { pair };
                    res.AddRange(points.Skip(2).ToList().GetPairs());  // recursion
                    return res;
                }
                else
                    return new List<LineSegment<Point>>();
            }
        }
    }
