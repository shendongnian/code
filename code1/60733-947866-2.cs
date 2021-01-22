    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public class Node
    {
        private static readonly char[] Braces = "{}".ToCharArray();
        private static readonly char[] StringTrim = "\" ".ToCharArray();
    
        public Node Parent { get; set; }
        public int ParentId { get; private set; }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Position { get; private set; }
        private readonly List<Node> children = new List<Node>();
        public List<Node> Children { get { return children; } }
    
        public static Node FromLine(string line)
        {
            Node node = new Node();
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
                    Node node = Node.FromLine(line);
                    dictionary[node.Id] = node;
                }
            }
            foreach (Node node in dictionary.Values)
            {
                if (node.ParentId != 0)
                {
                    node.Parent = dictionary[node.ParentId];
                    node.Parent.Children.Add(node);
                }
            }
    
            foreach (Node node in dictionary.Values)
            {
                node.Children.Sort((n1, n2) =>
                                   n1.Position.CompareTo(n2.Position));
            }
            
            Node root = dictionary[1];
            root.Dump();
        }
    }
