    private void SelectionChangedHandler(object sender, SelectionChangedEventArgs e)
    {
        // Avoid entering an infinite loop
        if (e.AddedItems.Count == 0)
        {
            return;
        }
        
        IList selectedItems = e.AddedItems;
        string val = selectedItems.OfType<string>().FirstOrDefault();
        
        NavigationService.Navigate(new Uri(val));
        
        // Clear the listbox selection
        ((ListBox)sender).SelectedItem = null;
    }
