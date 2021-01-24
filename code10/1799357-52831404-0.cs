    class SecondMethod
    {
        public void Method2(string[] args)
        {
            SecondMethod y = new SecondMethod();
            Console.WriteLine("{0}", y.number1);
            y.number1 = 33;
            Console.WriteLine("{0}", y.number1);
            Console.ReadKey();
        }
    }
