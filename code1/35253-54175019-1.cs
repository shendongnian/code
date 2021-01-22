    using System;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace PredicateExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Predicate<Node> backboneArea = Node =>  Node.Node_Area == 0 ;
                List<Node> Nodes = new List<Node>();
                Nodes.Add(new Node { Ip_Address = "1.1.1.1", Node_Area = 0, Node_Name = "Node1" });
                Nodes.Add(new Node { Ip_Address = "2.2.2.2", Node_Area = 1, Node_Name = "Node2" });
                Nodes.Add(new Node { Ip_Address = "3.3.3.3", Node_Area = 2, Node_Name = "Node3" });
                Nodes.Add(new Node { Ip_Address = "4.4.4.4", Node_Area = 0, Node_Name = "Node4" });
                Nodes.Add(new Node { Ip_Address = "5.5.5.5", Node_Area = 1, Node_Name = "Node5" });
                Nodes.Add(new Node { Ip_Address = "6.6.6.6", Node_Area = 0, Node_Name = "Node6" });
                Nodes.Add(new Node { Ip_Address = "7.7.7.7", Node_Area = 2, Node_Name = "Node7" });
    
                foreach( var item in Nodes.FindAll(backboneArea))
                {
                    Console.WriteLine("Node Name " + item.Node_Name + " Node IP Address " + item.Ip_Address);
                }
    
                Console.ReadLine();
            }
        }
    }
