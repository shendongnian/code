    RemoteDataContext rdt;
    private void GetRemoteDataContext() {    
       rdt = new RemoteDataContext(RemoteServerConnectionString);
    }
    private void FillFromRemoteDataContext() { 
        if (lblTest.Dispatcher.Thread != Thread.CurrentThread) {
            lblTest.Dispatcher.Invoke(delegate { lblTest.text = rdt.TestTable.First().TestField}); 
        } 
        else {
            lblTest.text = rdt.TestTable.First().TestField;
        }
    }
    private void Form1_Shown(object sender, EventArgs e) {    
        ThreadPool.QueueUserWorkItem(delegate {        
            try {            
                GetRemoteDataContext();            
                FillFromRemoteDataContext();        
            } catch { }  // ignore connection errors, just don't display data   
        });    
    }
