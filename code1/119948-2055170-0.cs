    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    static class Program {
        static void Main() {
            PointCollection points = new PointCollection();
            points.Add(new Point(1, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(3, 3));
            points.Add(new Point(4, 4));
            points.Add(new Point(5, 5));
            points.Add(new Point(6, 6));
            points.Add(new Point(7, 7)); // odd number to test end
    
            foreach (Tuple<Point, Point> pair in GetPairs(points)) {
                Console.WriteLine("From " + pair.Value1 + " to " + pair.Value2);
            }
        }
        public static IEnumerable<Tuple<Point, Point>>
                GetPairs(PointCollection points) {
            using (IEnumerator<Point> iter = points.GetEnumerator()) {
                while (iter.MoveNext()) {
                    Point value1 = (Point)iter.Current;
                    if (!iter.MoveNext()) { yield break; }
                    yield return new Tuple<Point, Point>(value1, (Point)iter.Current);
                }
            }
        }
    }
    public struct Tuple<T1, T2> {
        public T1 Value1 { get { return value1; } }
        public T2 Value2 { get { return value2; } }
        private readonly T1 value1;
        private readonly T2 value2;
        public Tuple(T1 value1, T2 value2) {
            this.value1 = value1;
            this.value2 = value2;
        }
    }
