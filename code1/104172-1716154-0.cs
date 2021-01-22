    private bool _hasInitialized = false;
    private void Form1_Shown(object sender, EventArgs e)
    {    
        if (!_hasInitialized)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.Sleep(200); // brief sleep to allow the main thread
                                   // to paint the form nicely
                this.Invoke((Action)delegate { LoadData(); });    
            });
        }
    }
    
    private void LoadData()
    {
        // do the data loading
        _hasInitialized = true;
    }
