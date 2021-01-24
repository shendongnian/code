        private void ShowCustom_OnClick(object sender, RoutedEventArgs e)
        {
            custom.Visibility = Visibility.Visible;
            Osm.Visibility = Visibility.Collapsed;
        }
        private void ShowReplace_OnClick(object sender, RoutedEventArgs e)
        {
            custom.Visibility = Visibility.Collapsed;
            Osm.Visibility = Visibility.Visible;
        }
