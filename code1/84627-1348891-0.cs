    B child = new B(this, manualResetEvent);
    ... etc...
    Class B
    {
    private A parent;
    private ManualResetEvent manualResetEvent;
    public B(A p, ManualResetEvent mre)
    {
        parent = p;
        manualResetEvent = mre;
        ... etc ...
    private void Manage()
    {
        ... do some work ...
        ... call some functions ...
        parent.DoIt(param);
        ... etc...
