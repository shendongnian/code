    List<AutoResetEvent> events = new List<AutoResetEvent>();
    AutoResetEvent loadTable1 = new AutoResetEvent(false);
    events.Add(loadTable1);
    ThreadPool.QueueUserWorkItem(delegate 
    { 
         SqlCommand1.BeginExecuteReader;
         SqlCommand1.EndExecuteReader;
         DataTable1.Load(DataReader1);
         loadTable1.Set();
    });
    
    AutoResetEvent loadTable2 = new AutoResetEvent(false);
    events.Add(loadTable2);
    ThreadPool.QueueUserWorkItem(delegate 
    { 
         SqlCommand2.BeginExecuteReader;
         SqlCommand2.EndExecuteReader;
         DataTable2.Load(DataReader2);
         loadTable2.Set();
    });
    // wait until both tables have loaded.
    WaitHandle.WaitAll(events.ToArray());
