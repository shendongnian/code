    private void NavView_Loaded(object sender, RoutedEventArgs e)
    {
            ...... 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                var IsSwitchingLanguage = ApplicationData.Current.LocalSettings.Values["IsSwitchingLanguage"];
                if (IsSwitchingLanguage != null)
                {
                    if ((bool)IsSwitchingLanguage)
                    {
                        NavView.SelectedItem = NavView.SettingsItem as NavigationViewItem;
                        ApplicationData.Current.LocalSettings.Values["IsSwitchingLanguage"] = false;
                        break;
                    }
                    
                }
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
            ......
    }
