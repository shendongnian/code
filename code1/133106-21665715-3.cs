    class MyMath
    {
        public dynamic Sum(dynamic x, dynamic y)
        {
            return (x+y);
        }
    }
    class Demo
    {
        static void Main(string[] args)
        {
            MyMath d = new MyMath();
            Console.WriteLine(d.Sum(23.2, 32.2));
        }
    }
