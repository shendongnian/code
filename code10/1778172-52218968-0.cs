     private void StyleCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTheme = StyleCombo.SelectedItem as ThemeNames;
            Application.Current.Resources.MergedDictionaries.Clear();
            // XAML
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.Data.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.DataVisualization.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.GridView.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.Pivot.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.PivotFieldList.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + selectedTheme.Value + ";component/Themes/Telerik.Windows.Controls.VirtualGrid.xaml", UriKind.RelativeOrAbsolute)
            });
    }
