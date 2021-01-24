    public void OnPathButtonClick(object sender, RoutedEventArgs e)
    {
    	string xamlPath = DesignerUtils
            .GetXamlPathFromActivityDesignerElement<MyPathActivityDesigner>
            (sender as FrameworkElement);
    	MessageBox.Show(xamlPath);
    }
