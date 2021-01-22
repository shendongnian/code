    using System;
    
    class Demo
    {
        private readonly Action action;
        
        public Demo(Action action)
        {
            this.action = action;
        }
        
        public void FirstMethod()
        {
            Console.WriteLine("In first method");
            action();
        }
    
        public void SecondMethod()
        {
            Console.WriteLine("In second method");
            action();
        }
    }
    
    class Test
    {
        static void Main()
        {
            Demo demo = new Demo(() => Console.WriteLine("Action called"));
            
            demo.FirstMethod();
            demo.SecondMethod();
        }
    }
