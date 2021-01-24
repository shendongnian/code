    public class Test
    {
        /// <summary>Returns a new Test with X set to the sum of lhs.X and rhs.X</summary>
        public static Test operator+ (Test lhs, Test rhs)
        {
            return new Test {X = lhs.X + rhs.X};
        }
        public int X;
    }
    class Program
    {
        public static void Main()
        {
            Test a = new Test {X = 1};
            Test b = new Test {X = 2};
            Test c = a + b;
        }
    }
                                                         
