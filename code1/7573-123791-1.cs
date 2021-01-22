    private BackgroundWorker worker = new BackgroundWorker();
    private AutoResetEvent _resetEvent = new AutoResetEvent(false);
    
    public Form1()
    {
        InitializeComponent();
    
        worker.DoWork += worker_DoWork;
    }
    
    public void Cancel()
    {
        worker.CancelAsync();
        _resetEvent.WaitOne(); // will block until _resetEvent.Set() call made
    }
    
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        while(!e.Cancel)
        {
            // do something
        }
    
        _resetEvent.Set(); // signal that worker is done
    }
