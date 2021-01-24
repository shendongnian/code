    private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var vm = DataContext as EntryItemListViewModel;
        vm.EntryItemViewModel.IsEntrySelected = true;
    }
