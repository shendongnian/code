    object _obj = new object();
    object obj
    {
        get
        {
            System.Diagnostics.StackFrame frame = new System.Diagnostics.StackFrame(1);
            System.Diagnostics.Trace.WriteLine(String.Format("Lock acquired by: {0} on thread {1}", frame.GetMethod().Name, System.Threading.Thread.CurrentThread.ManagedThreadId));
            return _obj;
        }
    }
    // Note that the code within lock(obj) and the lock itself remain unchanged.
    lock(obj)
    {
        // Do stuff
    }
