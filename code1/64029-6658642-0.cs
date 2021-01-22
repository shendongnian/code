    private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var behavior = sender as BindableSelectedItemBehaviour;
            if (behavior == null) return;
            var tree = behavior.AssociatedObject;
            if (tree == null) return;
            if (e.NewValue == null) 
                foreach (var item in tree.Items.OfType<TreeViewItem>())
                    item.SetValue(TreeViewItem.IsSelectedProperty, false);
            var treeViewItem = e.NewValue as TreeViewItem; 
            if (treeViewItem != null)
            {
                treeViewItem.SetValue(TreeViewItem.IsSelectedProperty, true);
            }
            else
            {
                var itemsHostProperty = tree.GetType().GetProperty("ItemsHost", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (itemsHostProperty == null) return;
                var itemsHost = itemsHostProperty.GetValue(tree, null) as Panel;
                if (itemsHost == null) return;
                foreach (var item in itemsHost.Children.OfType<TreeViewItem>())
                    if (WalkTreeViewItem(item, e.NewValue)) break;
            }
        }
        public static bool WalkTreeViewItem(TreeViewItem treeViewItem, object selectedValue) {
            if (treeViewItem.DataContext == selectedValue)
            {
                treeViewItem.SetValue(TreeViewItem.IsSelectedProperty, true);
                treeViewItem.Focus();
                return true;
            }
            foreach (var item in treeViewItem.Items.OfType<TreeViewItem>())
                if (WalkTreeViewItem(item, selectedValue)) return true;
            return false;
        }
