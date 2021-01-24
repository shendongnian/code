        public class Vector
        {
            public char Id { get; set; } // just for debug
            public double this[int i] { get { return Values[i]; } set { Values[i] = value; } }
            private List<double> Values { get; set; }
            public int Dim { get { return Values.Count; } }
            public Vector(double[] values) { Values = values.ToList(); }
            public Vector(int dims) { Values = new double[dims].ToList(); }
            // note this constructor, the one you posted actually copy the whole list object
            public Vector(List<double> values) { Values = new List<double>(values); }
            public static Vector operator +(Vector a, Vector b)
            {
                if (a.Dim != b.Dim)
                    throw new Exception();
                Vector c = new Vector(a.Dim) { Id = 'c' };
                for (int i = 0 ; i < c.Dim ; i++)
                    c[i] = a[i] + b[i];
                return c;
            }
        }
        static void Main(string[] args)
        {
            Vector a = new Vector(new double[] { 1.42857, 1.42857, 1.42857 }) { Id = 'a' };
            Vector b = new Vector(new double[] { 1.42857, 2.85714, 4.28571 }) { Id = 'b' };
            Vector c = a + b;
            Console.WriteLine(string.Format(">{0} = {1} + {2}", c.Id, a.Id, b.Id));
            Console.WriteLine(string.Format(">{1} + {2} = {0}", c[0], a[0], b[0]));
            Console.WriteLine(string.Format(">{1} + {2} = {0}", c[1], a[1], b[1]));
            Console.WriteLine(string.Format(">{1} + {2} = {0}", c[2], a[2], b[2]));
            Console.ReadKey();
        }
