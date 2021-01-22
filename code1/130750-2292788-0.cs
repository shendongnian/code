        private void BringSelectionIntoView(object sender, SelectionChangedEventArgs e)
        {
            Selector selector = sender as Selector;
            if (selector != null)
            {
                FrameworkElement selectedItem = selector.ItemContainerGenerator.ContainerFromItem(selector.SelectedItem) as FrameworkElement;
                if (selectedItem != null)
                {
                    selectedItem.BringIntoView();
                }
            }
        }
