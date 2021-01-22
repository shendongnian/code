    void Start()
    {
        this.o = new MyObject();
        this.o.ProcessingComplete += new EventHandler(this.OnProcessingComplete);
    
        // ...
    }
    void Stop()
    {
        this.o.ProcessingComplete -= new EventHandler(this.OnProcessingComplete);
    }
    
    void OnProcessingComplete(object sender, EventArgs e)
    {
        // ...
    }
