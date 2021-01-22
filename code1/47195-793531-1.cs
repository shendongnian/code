    using System;
    using System.Collections.Generic;
    
    static class Program {
        static void Main() {
            Node a = new Node("a"), b = new Node("b") { Children = {a}},
                c = new Node("c") { Children = {b}};
            foreach (Node node in c.Descendents()) {
                Console.WriteLine(node.Name);
            }
        }
    }
    
    class Node { // very simplified; no sanity checking etc
        public string Name { get; private set; }
        public List<Node> Children { get; private set; }
        public Node(string name) {
            Name = name;
            Children = new List<Node>();
        }
    }
    static class NodeExtensions {
        public static IEnumerable<Node> Descendents(this Node node) {
            if (node == null) throw new ArgumentNullException("node");
            if(node.Children.Count > 0) {
                foreach (Node child in node.Children) {
                    yield return child;
                    foreach (Node desc in Descendents(child)) {
                        yield return desc;
                    }
                }
            }
        }
    }
