    BackgroundWorker bw = null; 
    ObjectVB6 CS = null;
    public void DoCommand(object CommandSettings)
    {
        //ObjectVB6 is my custom class to allow easy calling of COM methods and properties
        CS = new ObjectVB6(CommandSettings);
        // hook up background worker
        bw = new BackgroundWorker();
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    }
    private void bw_DoWork(...)
    {
        // process data, e.g. the piece that takes too long
    }
    private void bw_RunWorkerCompleted
    {
       CS.CallMethod("MyReply", args);
    }
