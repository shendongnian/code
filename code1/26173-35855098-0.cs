    using System.Windows.Controls;
    namespace Extensions
    {
        public static class TreeViewEx
        {
            /// <summary>
            /// Select specified item in a TreeView
            /// </summary>
            public static void SelectItem(this TreeView treeView, object item)
            {
                var tvItem = treeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (tvItem != null)
                {
                    tvItem.IsSelected = true;
                }
            }
        }
    }
