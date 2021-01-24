    public static class Extensions
    {
        public static IEnumerable<TreeNode> FlattenTree(this TreeView source)
        {
            return FlattenTree(source.Nodes);
        }
    
        public static IEnumerable<TreeNode> FlattenTree(this TreeNodeCollection source)
        {
            return source.Cast<TreeNode>().Concat(source.Cast<TreeNode>().SelectMany(x => FlattenTree(x.Nodes)));
        }
    }
