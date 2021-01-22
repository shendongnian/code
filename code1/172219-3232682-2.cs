    private void SetupThread()
    {
        BackgroundWorker bw = new BackgroundWorker();
        // Assuming you need sender and e. If not, you can just send bw
        bw.DoWork += new DoWorkEventHandler(DoTheWork);
    }
    
    private void DoTheWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        MyClass.Callback = () => 
            {
                ((BackgroundWorker)bw).UpdateProgress(/*send your update here*/);
                MethodCalledFromEventCallback();
            };
        MyClass.DoSomething(); // This will produce a callback(event) from MyClass
    }
    
    private void MethodCalledFromEventCallback() 
    { 
        // You've already sent an update by this point, so no background parameter required
    }
