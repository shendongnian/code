      private void AllContactsDetailsNewItemAdded(object sender, RoutedEventArgs e)
        {
            // New item added so refresh the items listbox
            AllContactListItemsListBox.ItemsSource = from c in  ProoActive.App.ProActiveDatabaseEntities.Contacts select c;
        }
