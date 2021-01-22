    class TreeNode
    {
        public string Value { get; set;}
        public List<TreeNode> Nodes { get; set;}
        public TreeNode()
        {
            Nodes = new List<TreeNode>();
        }
    }
    Action<TreeNode> traverse = null;
    traverse = (n) => { Console.WriteLine(n.Value); n.Nodes.ForEach(traverse);};
    var root = new TreeNode { Value = "Root" };
    root.Nodes.Add(new TreeNode { Value = "ChildA"} );
    root.Nodes[0].Nodes.Add(new TreeNode { Value = "ChildA1" });
    root.Nodes[0].Nodes.Add(new TreeNode { Value = "ChildA2" });
    root.Nodes.Add(new TreeNode { Value = "ChildB"} );
    root.Nodes[1].Nodes.Add(new TreeNode { Value = "ChildB1" });
    root.Nodes[1].Nodes.Add(new TreeNode { Value = "ChildB2" });
    traverse(root);
