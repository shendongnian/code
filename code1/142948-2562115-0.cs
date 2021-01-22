        private static int GetNodeBounds(TreeNodeCollection nodes) {
            int w = 0;
            foreach (TreeNode node in nodes) {
                w = Math.Max(w, node.Bounds.Right);
                if (node.Nodes.Count > 0)
                    w = Math.Max(w, GetNodeBounds(node.Nodes));
            }
            return w;
        }
