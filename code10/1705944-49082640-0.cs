    public static class NavigationViewExtensions
    {
        public static void ClearSelection(this NavigationView navigationView)
        {
            var temporaryItem = new NavigationViewItem();
            navigationView.MenuItems.Add(temporaryItem);
            navigationView.SelectedItem = temporaryItem;
            navigationView.SelectedItem = null;
            navigationView.MenuItems.Remove(temporaryItem);
        }
    }
