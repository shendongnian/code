    using System.Linq;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    public static class Extensions
    {
        public static List<TreeNode> Descendants(this TreeView tree)
        {
            var nodes = tree.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => x.Descendants()).Concat(nodes).ToList();
        }
    
        public static List<TreeNode> Descendants(this TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>().ToList();
            return nodes.SelectMany(x => Descendants(x)).Concat(nodes).ToList();
        }
    }
