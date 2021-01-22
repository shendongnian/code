    public void pressButtonToDoSomeLongTimeWork()
    {    
        Mouse.OverrideCursor = Cursors.Wait;
        // before the long time work, change mouse cursor to wait cursor
        worker.DoWork += doWorkLongTimeAsync;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.RunWorkerAsync();  //start doing some long long time work but GUI can update
    }
    private void worker_RunWorkerCompleted(object sender,     
                                           RunWorkerCompletedEventArgs e)
    {
        //long time work is done();
        updateGuiToShowTheLongTimeWorkResult();
        Mouse.OverrideCursor = null;  //return mouse cursor to normal
    }
