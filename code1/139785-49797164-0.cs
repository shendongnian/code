     class Program
    {
        public static void Method1(object count)
        {
            int say = Convert.ToInt32(count);
            for (int i = 0; i <= say; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Method1));
            thread.Start(new object[] { 10, "Cavid" });
            Console.Read();
        }
    }
