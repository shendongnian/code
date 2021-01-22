    BindingSource bs = new BindingSource();
    DataTable dt = new DataTable();
     
    bs.DataSource = dt;
    bs.SuspendBinding();
    bs.RaiseListChangedEvents = false; 
    bs.Filter = "1=0"; 
    dt.BeginLoadData(); 
            
    //== some modification on data table
    
    dt.EndLoadData();
    bs.RaiseListChangedEvents = true;
    bs.Filter = "";
