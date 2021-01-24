    namespace MyExtensions
    {
        using System.Windows.Forms;
        public static class TreeNodeCollectionExtensions
        {
            //Just an example of a new signature, use the signature that you need instead:
            public static TreeNode Add(this TreeNodeCollection nodes, string text, int tag)
            {
                var node = nodes.Add(text);
                node.Tag = tag;
                return node;
            }
        }
    }
