    _GeneralList = SharedLists.GeneralList;
    _QueriedList = _GeneralList.Where(q =>q.ID >1000);
    
    // ***this line changed***
    cmbobox.ItemsSource = new ObservableCollection<DataService.Obj>(_QueriedList);
    
    DataService.Obj info = new DataService.Obj();
    info.ID = "0";
    (cmbobox.ItemsSource as ObservableCollection<DataService.Obj>).Insert(0,info);
    cmbobox.SelectedIndex = 0;
