    class Program 
    { 
        delegate int Fun (int a, int b); 
        void Execute()
        {
           Fun F1 = new Fun(Add); 
           int Res= F1(2,3); 
           Console.WriteLine(Res); 
        }
        static void Main(string[] args) 
        { 
            var program = new Program();
            program.Execute();
        } 
     
        int Add(int a, int b)
        { 
            int result; 
            result = a + b; 
            return result; 
        } 
    }
