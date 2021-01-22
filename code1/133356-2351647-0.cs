    ObservableCollection<MyTasks> visibleTasks = e.Result;
    var filteredResults = from visibleTask in visibleTasks
                          select visibleTask;
    
    filteredResults = filteredResults.Where(p => p.DueDate == DateTime.Today);
    visibleTasks = new ObservableCollection<MyTasks>(filteredResults);  // This throws a compile time error
