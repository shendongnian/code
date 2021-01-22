    class MyMath
    {
        public static T Add<T>(T a, T b) where T: struct
        {
            switch (typeof(T).Name)
            {
                case "Int32":
                    return (T) (object)((int)(object)a + (int)(object)b);
                case "Double":
                    return (T)(object)((double)(object)a + (double)(object)b);
                default:
                    return default(T);
            }
        }
    }
    class Program
    {
        public static int Main()
        {
            Console.WriteLine(MyMath.Add<double>(3.6, 2.12));
            return 0;
        }
    }
