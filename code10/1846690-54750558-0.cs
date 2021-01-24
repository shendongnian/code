    var ptx = new Task(() => DoWork(myWorker, fileProgressBar, gridPartEdgeDetails));
    					myWorker.file_Path = filePath;
    					ptx.Start(); 
    static void DoWork(CVS_Worker x, ProgressBar pb, DataGrid dg)
    {
        var parts = new List<Part>();
    	parts     = x.DoMyStuff(pb);  //pass in my progressbar
    
    	//Update Datagrid
    	dg.Dispatcher.Invoke(() =>
    	{
    	    dg.ItemsSource = parts;
    	});
    } 
