        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in tv.Items)
            {
                TreeViewItem tvi = tv.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                tvi.IsExpanded = true;
                await Task.Delay(50);
                recurseItem(tvi);
            }
        }
        private bool gotTheItem = false;
        private void recurseItem(TreeViewItem item)
        {
            foreach (var subItem in item.Items)
            {
                TreeViewItem tvi = item.ItemContainerGenerator.ContainerFromItem(subItem) as TreeViewItem;
                // do something
                if (!gotTheItem)
                    recurseItem(tvi);
            }
        }
