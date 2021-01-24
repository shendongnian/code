    private YourViewModel vm;
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems)
        {
            vm.SelectedThings.Add(item);
        }
        foreach (var item in e.RemovedItems)
        {
            vm.SelectedThings.Remove(item);
        }
    }
