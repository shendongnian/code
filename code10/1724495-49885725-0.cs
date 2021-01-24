        private void GetVisibleNodes(TreeNode node)
        {
            visibleNodes.Add(node);
            if (node.IsExpanded)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    GetVisibleNodes(childNode);
                }
            }
        }
