    private void Button_Click(object sender, RoutedEventArgs e)
    {
            foreach (var item in selectedItems)
            {
                Trilogi.Items.Remove(item);
            }
            callMethodToRemoveItemsToXML();
            selectedItems.Clear();
    }
