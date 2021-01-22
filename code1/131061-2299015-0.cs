    class Program
    {
        delegate int Fun (int a, int b);
        static void Main(string[] args)
        {
            Program p = new Program();       // create instance of Program
            Fun F1 = new Fun(p.Add);         // now your non-static method can be referenced
            int Res= F1(2,3);
            Console.WriteLine(Res);
        }
        public int Add(int a, int b)
        {
            int result;
            result = a + b;
            return result;
        }
    }
