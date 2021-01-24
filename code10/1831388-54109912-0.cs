    _lvUsers.ItemsSource = _config.listTestBenches;
    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_lvUsers.ItemsSource);
    PropertyGroupDescription groupDescription = new PropertyGroupDescription("type");
    view.GroupDescriptions.Add(groupDescription);
    view.SortDescriptions.Add(new SortDescription("type", ListSortDirection.Ascending));
