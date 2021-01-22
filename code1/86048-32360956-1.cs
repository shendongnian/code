    public static class Extensions
    {
        public static List<TreeNode> GetAllNodes(this TreeView tree)
        {
            var firstLevelNodes = tree.Nodes.Cast<TreeNode>();
            return firstLevelNodes.SelectMany(x => GetNodes(x)).Concat(firstLevelNodes).ToList();
        }
    
        private static IEnumerable<TreeNode> GetNodes(TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => GetNodes(x)).Concat(nodes);
        }
    }
