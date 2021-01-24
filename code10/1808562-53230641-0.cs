        public void ElementContextMenuItemClick(object sender, RoutedEventArgs e) {
            MenuItem selectedMenuItem = (MenuItem)e.OriginalSource;
            String command = selectedMenuItem.Header.ToString();
            SwimLaneController.Instance.ProcessContextMenuCommand(this, command);
        }
