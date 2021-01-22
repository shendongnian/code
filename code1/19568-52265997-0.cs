    private void ListBox_OnPreviewMouseDown (object sender, MouseButtonEventArgs e)
    {
        // I have a special extension for GetParent, numerous examples on the internet of how you would do that
        var lbi = ((DependencyObject) e.OriginalSource).GetParent<ListBoxItem>();
        if (lbi != null && lbi.IsSelected)
        {
            lbi.IsSelected = false;
            e.Handled = true;
        }
    }
