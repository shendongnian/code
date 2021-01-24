    protected override void Initialize(RequestContext requestContext)
    {
         System.IO.File.AppendAllText(tPath, "Thread enter and ID is: " + 
             System.Threading.Thread.CurrentThread.ManagedThreadId + Environment.NewLine);
         // Placed all code here
         System.IO.File.AppendAllText(tPath, "Thread exit and ID is: " + 
             System.Threading.Thread.CurrentThread.ManagedThreadId + Environment.NewLine);
    }
