    RemoteDataContext rdt;
    private void GetRemoteDataContext() {    
       rdt = new RemoteDataContext(RemoteServerConnectionString);
    }
    private void FillFromRemoteDataContext() {   
        lblTest.text = rdt.TestTable.First().TestField;
    }
    private void Form1_Shown(object sender, EventArgs e) {    
        Thread t = new Thread(new ThreadStart(new delegate {        
            try {            
                GetRemoteDataContext();            
                FillFromRemoteDataContext();        
            } catch { }  // ignore connection errors, just don't display data    
        );    
        t.Start;
    }
