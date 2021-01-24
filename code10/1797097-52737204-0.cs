            public static void Main(string[] args)
            {
                Fibonacci fibo = new Fibonacci();
        
                foreach(var element in fibo.getSequence(9))
                {
                     Console.WriteLine(element);
                }
    
                Console.ReadLine();
            }
