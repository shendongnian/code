    public class LazyMatrix
    {
        public static implicit operator Matrix(LazyMatrix l)
        {
            Matrix m = new Matrix();
            foreach (Matrix x in l.Pending)
            {
                for (int i = 0; i < 2; ++i)
                    for (int j = 0; j < 2; ++j)
                        m.Contents[i, j] += x.Contents[i, j];
            }
            return m;
        }
        public List<Matrix> Pending = new List<Matrix>();
    }
    public class Matrix
    {
        public int[,] Contents = { { 0, 0 }, { 0, 0 } };
        public static LazyMatrix operator+(Matrix a, Matrix b)
        {
            LazyMatrix l = new LazyMatrix();
            l.Pending.Add(a);
            l.Pending.Add(b);
            return l;
        }
        public static LazyMatrix operator+(Matrix a, LazyMatrix b)
        {
            b.Pending.Add(a);
            return b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix();
            Matrix b = new Matrix();
            Matrix c = new Matrix();
            Matrix d = new Matrix();
            a.Contents[0, 0] = 1;
            b.Contents[1, 0] = 4;
            c.Contents[0, 1] = 9;
            d.Contents[1, 1] = 16;
            Matrix m = a + b + c + d;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    System.Console.Write(m.Contents[i, j]);
                    System.Console.Write("  ");
                }
                System.Console.WriteLine();
            }
            System.Console.ReadLine();
        }
    }
