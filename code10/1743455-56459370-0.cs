    public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    ...
    
    Task.Factory.StartNew<Model>(() =>
    {
        //My Work that writes log
    }, TaskCreationOptions.AttachedToParent).ContinueWith((t) =>
    {
        //Update UI code using that also writes log
    }, TaskScheduler.FromCurrentSynchronizationContext());
