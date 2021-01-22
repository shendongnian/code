    // the event handler. in this case preped for cross thread calls  
    void OnEventMyWhatever(object sender, MyUpdateEventArgs e)
    {
        if (!this.IsHandleCreated) return;
        if (InvokeRequired) 
        {
            try
            {
                Invoke(new MyUpdateCallback(this.MyUpdate), e.MyData);
            }
            catch (InvalidOperationException ex)    // pump died before we were processed
            {
                if (this.IsHandleCreated) throw;    // not the droids we are looking for
            }
        }
        else
        {
            this.MyUpdate(e.MyData);
        }
    }
    // the update function
    void MyUpdate(Object myData)
    {
        ...
    }
