    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            a.eventOne += (s, e) => Console.WriteLine("One");
            a.eventTwo += (s, e) => Console.WriteLine("Two");
            a.RaiseOne();
            a.RaiseTwo();
    				// won't compile
            a.eventOne(null, EventArgs.Empty);
            a.eventTwo(null, EventArgs.Empty);
        }
    
    }
    
    class A {
        public event EventHandler eventOne;
        public EventHandler eventTwo;
    
        public void RaiseOne()
        {
            if (eventOne != null)
                eventOne(this, EventArgs.Empty);
        }
    
        public void RaiseTwo()
        {
            if (eventTwo != null)
                eventTwo(this, EventArgs.Empty);
        }
    }
