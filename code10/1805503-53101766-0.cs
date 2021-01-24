    ...
    dc.TicketTables.InsertOnSubmit(x);
    dc.SubmitChanges();
    var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    if (mainWindow != null)
    {
        var sourceCollection = mainWindow.AllTasksListView as ObservableCollection<TicketTable>;
	    if (sourceCollection != null)
	        sourceCollection.Add(x);
    }
