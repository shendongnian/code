    public class TreeNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentID { get; set; }
        public List<TreeNode> Children { get; set; }
        public TreeNode()
        {
            Id = Name = ParentID = string.Empty;
            Children = new List<TreeNode>();
        }
        public bool IsRoot { get { return ParentID == string.Empty; } }
        public bool IsChild { get { return Children == null || Children.Count == 0; } }
    }
