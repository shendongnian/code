    private void SetupThread()
    {
        BackgroundWorker bw = new BackgroundWorker();
        // Assuming you need sender and e. If not, you can just send bw
        bw.DoWork += (sender, e) => DoTheWork(sender, e, bw);
    }
    
    
    private void DoTheWork(object sender, System.ComponentModel.DoWorkEventArgs e, 
        BackgroundWorker bw)
    {
        // You must be setting the callback somewhere...
        // Lambda version
        MyClass.Callback = () => MethodCalledFromEventCallback(bw);
        // anonymous delegate version (if you can't use a lambda for some reason)
        MyClass.Callback = delegate() { MethodCalledFromEventCallback(bw); }
        MyClass.DoSomething(); // This will produce a callback(event) from MyClass
    }
    
    private void MethodCalledFromEventCallback(BackgroundWorker bw)
    {
       // You should now have the background worker object
    
    }
