    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<ReturnItem> list = new List<ReturnItem>();
                list.Add(new ReturnItem(1, "mouse"));
                list.Add(new ReturnItem(2, "mickey"));
    
                list = list.OrderBy(i => i._column._name).ToList();
    
                list.ForEach(i => Console.WriteLine(i._column._name));
                Console.Read();
            }
        }
    
        class ReturnItem
        {
            public int _id;
            public Columns _column;
            
    
            public ReturnItem(int id, string name)
            {
                _id = id;
                _column = new Columns(name);
    
            }
        }
    
        class Columns
        {
            public string _name;
    
            public Columns(string name)
            {
                _name = name;
            }
        }
    }
