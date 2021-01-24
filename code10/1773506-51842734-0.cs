    private void newViewModelButton_Click(object sender, RoutedEventArgs e)
    {
        var mvm = new MainViewModel();
        DataContext = mvm;
        mvm.WidgetView.SortDescriptions.Add(new SortDescription("Rank", ListSortDirection.Ascending));
        mvm.WidgetView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
    }
