    private IEnumerable<DataService.Obj> _GeneralList; 
    private IEnumerable<DataService.Obj> _QueriedList; 
     
    private void Bind() 
    { 
        _GeneralList = SharedLists.GeneralList; 
        _QueriedList = _GeneralList.Where(q =>q.ID >1000).ToList(); 
     
        DataService.Obj info = new DataService.Obj(); 
        info.ID = "0"; 
        _QueriedList.Insert(0,info); 
    
        cmbobox.ItemsSource = _QueriedList; 
     
        cmbobox.SelectedIndex = 0; 
    } 
