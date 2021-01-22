    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public class RawNode
    {
        public int Id { get; private set; }
        public int ParentId { get; private set; }
        public int Position { get; private set; }
        public string Title { get; private set; }
        
        private static readonly char[] Braces = "{}".ToCharArray();
        private static readonly char[] StringTrim = "\" ".ToCharArray();
        
        public static RawNode FromLine(string line)
        {
            RawNode node = new RawNode();
            line = line.Trim(Braces);
            string[] bits = line.Split(',');
            foreach (string bit in bits)
            {
                string[] keyValue = bit.Split('=');
                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();
                switch (key)
                {
                    case "Id":
                        node.Id = int.Parse(value);
                        break;
                    case "ParentId":
                        node.ParentId = int.Parse(value);
                        break;
                    case "Position":
                        node.Position = int.Parse(value);
                        break;
                    case "Title":
                        node.Title = value.Trim(StringTrim);
                        break;
                    default:
                        throw new ArgumentException("Bad line: " + line);
                }
            }
            return node;
        }
    }
    
    
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
            var dictionary = new Dictionary<int, Node>();
            
            using (TextReader reader = File.OpenText("test.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RawNode raw = RawNode.FromLine(line);
                    Node parent = raw.ParentId == 0 ? null : dictionary[raw.ParentId];
                    Node node = new Node { Id = raw.Id, Parent = parent, Title = raw.Title };
                    if (parent != null)
                    {
                        parent.Children.Add(node);
                    }
                    dictionary[node.Id] = node;
                }
            }
            
            Node root = dictionary[1];
            root.Dump();
        }
    }
