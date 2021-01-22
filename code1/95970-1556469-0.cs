        static void go()
        {
            Console.WriteLine("Nice Work");
        }
      
        public void Run()
        {
            ThreadStart starter1 = delegate() { go(); };
            ThreadStart starter2 = delegate() { Console.WriteLine("Hello");};
            
            ThreadStart starter3 = () =>  Console.WriteLine("Hello");
        }
