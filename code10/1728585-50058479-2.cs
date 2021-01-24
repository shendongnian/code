    using System;
    using System.Collections.Generic;
    
    class Container
    {
        public List<string> List { get; private set; }
            = new List<string>();
    }
    
    class Program
    {
        static void Main()
        {
            var container = new Container();
            var list = container.List;
            Console.WriteLine(list.Count); //0
            
            container.List.Add("foo");
            Console.WriteLine(list.Count); // 1        
        }
    }
