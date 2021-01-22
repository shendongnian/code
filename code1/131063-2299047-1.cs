    class MyClass
    {
        public MyClass()
        {
            Fun F1 = new Fun(Add);
            int Res = F1(2, 3);
            Console.WriteLine(Res);
        }
    
        public int Add(int a, int b)
        {
            int result;
            result = a + b;
            return result;
        }
    }
