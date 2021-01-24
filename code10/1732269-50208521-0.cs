    using System;
    
    class Program
    {
        static void Main()
        {
            var riddle = new Riddle();
            ((ICounter)riddle.counter).Increment();
            
            Console.WriteLine(((Counter)riddle.counter).Count); // Line B
        }
    }
    
    interface ICounter
    {
        void Increment();
    }
    
    struct Counter : ICounter
    {
        private int x;
        public void Increment() { this.x++; }
        public int Count { get { return this.x; } }
    }
    
    class Riddle
    {
        public readonly object counter = new Counter();
    }
