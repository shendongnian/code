        public void HandleTreeItems(Action<TreeItem> item, TreeItem parent)
        {
            if (parent.Children.Count > 0)
            {
                foreach (TreeItem ti in parent.Children)
                {
                    HandleTreeItems(item, ti);
                }
            }
            item(parent);
        }
