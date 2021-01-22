    using System;
    using System.Collections.Generic;
    
    public class Node
    {
        public int Id { get; set; }
        public string Title { get; set; }
        private readonly List<Node> children = new List<Node>();
        public List<Node> Children { get { return children; } }
        public Node Parent { get; set; }
        
        public void Dump()
        {
            int depth = 0;
            Node node = this;
            while (node.Parent != null)
            {
                depth++;
                node = node.Parent;
            }
            Console.WriteLine(new string(' ', depth * 2) + Title);
            foreach (Node child in Children)
            {
                child.Dump();
            }
        }
    }
    
    class Test
    {       
        static void Main(string[] args)
        {
            var rawData = new[] {
                new { Id = 1, ParentId = 0, Position = 0, Title = "root" },
                new { Id = 2, ParentId = 1, Position = 0, Title = "child 1" },
                new { Id = 3, ParentId = 1, Position = 1, Title = "child 2" },
                new { Id = 4, ParentId = 1, Position = 2, Title = "child 3" },
                // Note "fixed" data here (at a guess)
                new { Id = 5, ParentId = 3, Position = 0, Title = "grandchild 1" }
            };
            
            var dictionary = new Dictionary<int, Node>();
            
            foreach (var raw in rawData)
            {
                Node parent = raw.ParentId == 0 ? null : dictionary[raw.ParentId];
                Node node = new Node { Id = raw.Id, Parent = parent, Title = raw.Title };
                if (parent != null)
                {
                    parent.Children.Add(node);
                }
                dictionary[node.Id] = node;
            }
            Node root = dictionary[1];
            root.Dump();
        }
    }
