    public static class NavigationViewExtension
    {
        public static void ClearSelection(this NavigationView navigationView)
        {
            var temporaryItem = new NavigationViewItem();
            if (navigationView.MenuItemsSource != null)
            {
                var existingList = ((IList)(navigationView.MenuItemsSource));
                existingList.Add(temporaryItem);
                navigationView.SelectedItem = temporaryItem;
                navigationView.SelectedItem = null;
                existingList.Remove(temporaryItem);
            }
            else
            {
                navigationView.MenuItems.Add(temporaryItem);
                navigationView.SelectedItem = temporaryItem;
                navigationView.SelectedItem = null;
                navigationView.MenuItems.Remove(temporaryItem);
            }
        }
    }
