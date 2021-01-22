    using System;
    
    class Bar
    {
        public int Amount { get; private set; }
    
        public Bar() : this(5) { }
    
        public Bar(int amount)
        {
            Amount = amount;
        }
    }
    
    class Program
    {
    
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            Console.WriteLine(bar.Amount);
        }
    }
