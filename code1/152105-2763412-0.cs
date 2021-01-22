    public void SomeMethod() 
    { 
    
    System.ComponentModel.BackgroundWorker myWorker = new  System.ComponentModel.BackgroundWorker();
    
    myWorker.DoWork += myWorker_DoWork;
    
    myWorker.RunWorkerAsync();
    
    }
    
    private void myWorker_DoWork(object sender,
       System.ComponentModel.DoWorkEventArgs e)
    {
       // Do time-consuming work here
    }
