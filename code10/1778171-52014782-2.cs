    private void btnChangeTheme_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
        {
            Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute)
        });
        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
        {
            Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute)
        });
        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
        {
            Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute)
        });
    }
