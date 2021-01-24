    using System.Collections.Generic;
    using System.Windows.Forms;
    public class NodeHelper
    {
        public static List<TreeNode> ToList(TreeNodeCollection nodes)
        {
            List<TreeNode> list = new List<TreeNode>();
            foreach (TreeNode node in ToIEnumerable(nodes))
                list.Add(node);
            return list;
        }
        public static IEnumerable<TreeNode> ToIEnumerable(TreeNodeCollection nodes)
        {
            foreach (TreeNode c1 in nodes)
            {
                yield return c1;
                foreach (TreeNode c2 in ToIEnumerable(c1.Nodes))
                {
                    yield return c2;
                }
            }
        }
    }
