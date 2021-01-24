    class Program
    {
        static void Main(string[] args)
        {
            var results = "1234567890"
                          .Select(o => new Test(o))
                          .Where(o => o.Value > '3' && o.Value < '7')
                          .ToList();
    
            // do something with results
            // ...
    
            // dispose
            foreach (var result in results)
                result.Dispose();
    
            // Force GC to prove dispose called...
            GC.Collect();
    
            Console.ReadLine();
        }
    }
    class Test : IDisposable
    {
        public char Value { get; }
        public Test(char value)
        {
            Value = value;
            Console.WriteLine($"{Value}");
        }
        public void Dispose() => Console.WriteLine($"{Value} disposed");
    
        ~Test()
        {
            Dispose();
        }
    }
