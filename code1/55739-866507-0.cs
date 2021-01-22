        public static class TreeNodeCollectionExtensions
        {
            public static IEnumerable<TreeNode> ToEnumerable(this TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                {
                    yield return node;
                }
            }
        }
