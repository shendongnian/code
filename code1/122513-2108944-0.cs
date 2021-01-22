    ThreadPool.QueueUserWorkItem(delegate 
    { 
         SqlCommand1.BeginExecuteReader;
         SqlCommand1.EndExecuteReader;
         DataTable1.Load(DataReader1);
    });
    
    ThreadPool.QueueUserWorkItem(delegate 
    { 
         SqlCommand2.BeginExecuteReader;
         SqlCommand2.EndExecuteReader;
         DataTable2.Load(DataReader2);
    });
