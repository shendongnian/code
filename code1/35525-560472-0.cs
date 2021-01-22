    delegate void dowork();
    private static void WorkDone(IAsyncResult result)
    {
       ((dowork)result.AsyncState).EndInvoke(result);
        // this function is called when the delegate completes
    }
    public void Start()
    {
        dowork dw = delegate {// code in this block has it's own thread };
        dw.BeginInvoke(WorkDone, null);
    }
