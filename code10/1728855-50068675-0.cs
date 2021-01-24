        private async void NavView_SelectionChanged(
               NavigationView sender, 
               NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                NavView.Header = "Settings";
                //rootFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                if (args.SelectedItem != null)
                {
                    NavigationViewItem item  
                        = args.SelectedItem as NavigationViewItem;
                    NavView.Header = item.Tag;
                    await Dispatcher.RunAsync(
                          Windows.UI.Core.CoreDispatcherPriority.Normal,
                         () => {
                              NavView.SelectedItem = null;
                              NavView.Header = item.Tag;
                    });
                }
                else
                {
                    NavView.Header = "Null";
                }
            }
        }
