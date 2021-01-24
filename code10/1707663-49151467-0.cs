    public class TreeStructure
    {
        public TreeStructure Parent { get; set; }
        public decimal Id { get; set; }
        public List<TreeStructure> Childrens { get; set; } = new List<TreeStructure>();
        public TreeStructure(decimal id, TreeStructure parent)
        {
            Id = id;
            Parent = parent;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public TreeStructure GetTopParent()
        {
            var tree = this;
            while (tree.Parent != null)
            {
                tree = tree.Parent;
            }
            return tree;
        } 
    }
