    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> inputs = new List<string>(){"1_2", "5_3", "2_5", "2_4"};
                Node.CreateTree(inputs);
                Node.Print();
            }
        }
        public class Node
        {
            public static Node root;
            public static Dictionary<int, Node> nodes = null;
            public int name { get; set; }
            public Node parent = null;
            public List<Node> neighbors { get; set; }
            public static void CreateTree(List<string> inputs)
            {
                //assume no loops
                Dictionary<int, List<int>> orderedPathsDict = inputs.Select(x => x.Split(new char[] { '_' }).Select(y => int.Parse(y)))
                    .GroupBy(x => x.First(), y => y.Last())
                    .ToDictionary(x => x.Key, y => y.ToList());
                Node childNode = null;
                //create Nodes
                nodes = orderedPathsDict.GroupBy(x => x.Key, y => new Node() { name = y.Key }).ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //create Tree from dictionary
                //parent is key of dictionary
                foreach (KeyValuePair<int,List<int>> parentChild in orderedPathsDict)
                {
                    Node parent = nodes[parentChild.Key];
                    foreach (int child in parentChild.Value)
                    {
                        //check if child is in list of Nodes
                        if (nodes.ContainsKey(child))
                        {
                            childNode = nodes[child];
                        }
                        else
                        {
                            childNode = new Node() { name = child }; 
                            nodes.Add(child,childNode);
                        }
                        if (parent.neighbors == null) parent.neighbors = new List<Node>();
                        parent.neighbors.Add(childNode);
                        childNode.parent = parent;
                    }
                }
                //get root which is the node with no parent
                root = nodes.Where(x => x.Value.parent == null).FirstOrDefault().Value;
            }
            public static void Print()
            {
                foreach (KeyValuePair<int,Node> node in nodes)
                {
                    PrintRecursive(node.Value, node.Key.ToString());
                }
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }
            private static void PrintRecursive(Node parent, string ancestors)
            {
                if (parent.neighbors != null)
                {
                    foreach (Node neighbor in parent.neighbors)
                    {
                        string newAncestors = ancestors + "_" + neighbor.name.ToString();
                        Console.WriteLine(newAncestors);
                        PrintRecursive(neighbor, newAncestors);
                    }
                }
            }
        }
    }
