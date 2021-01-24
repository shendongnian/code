    using System;
    using System.Collections.Generic;
    
    class Container
    {
        private readonly List<string> list = new List<string>();
        
        public IReadOnlyList<string> ListView { get; }
        
        public Container()
        {
            ListView = list.AsReadOnly();
        }
        
        public void AddItem(string item)
        {
            list.Add(item);
        }
    }
    
    class Program
    {
        static void Main()
        {
            var container = new Container();
            Console.WriteLine(container.ListView.Count); //0
            
            // container.ListView.Add("foo"); // Compile-time error
            
            container.AddItem("foo");
            Console.WriteLine(container.ListView.Count); // 1        
        }
    }
