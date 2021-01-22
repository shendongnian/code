     class Program
    {
        public static void Method1(object param)
        {
            object[] parameters = (object[])param;
            int param1 = (int)parameters[0];
            string param2 = (string)parameters[1];
            Console.WriteLine("Int : {0}  \nString : {1}", param1, param2);
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Method1));
            thread.Start(new object[] { 10, "String value" });
            Console.Read();
        }
    }
