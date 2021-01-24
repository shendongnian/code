    private void OnGroupChange(object sender, RoutedEventArgs e)
    {
        DataGridRow row = null;
        for (var visible = (Visual)sender; visible != null; visible = VisualTreeHelper.GetParent(visible) as Visual)
        {
            if (visible.GetType() != typeof(DataGridRow))
                continue;
            row = (DataGridRow)visible;
            var appName = (ExtenedApplicationFile)row.Item;
            ((ApplicationsViewModel)DataContext).SelectedApplicationFile = appName;
            break;
        }
        if (row != null)
        {
            Visibility currentVisibility = row.DetailsVisibility;
            CollapseGroupDetails();
            row.DetailsVisibility = currentVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        else
        {
            CollapseGroupDetails();
        }
        Applications.UpdateLayout();
    }
