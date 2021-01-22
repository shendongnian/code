    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleTestCSharp
    {
        class Node : IEnumerable<Node>
        {
            public string Name { get; private set; }
            private List<Node> _list = new List<Node>();
    
            public Node(string name)
            {
                Name = name;
            }
    
            public void Add(Node child)
            {
                _list.Add(child);
            }
    
            public Node this[string name]
            {
                get
                {
                    return _list.First(el => el.Name == name);
                }
            }
       
            public IEnumerator<Node> GetEnumerator()
            {
     	        return _list.GetEnumerator();
            }
    
            IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
     	        return _list.GetEnumerator();
            }
    
            public override string ToString()
            {
                return Name;
            }
        }   
    
        class Program
        {
    
            static void Main(string[] args)
            {
                var root = new Node("root");
                root.Add(new Node("1st child"));
                root.Add(new Node("2nd child"));
                root.Add(new Node("3rd child"));
    
                var firstchild = root["1st child"];
    
                foreach (var child in root)
                {
                    Console.WriteLine(child);
                }
            }
        }
    }
