    public static class DelayedDelegate
    {
    
        static Timer runDelegates;
        static Dictionary<MethodInvoker, DateTime> delayedDelegates = new Dictionary<MethodInvoker, DateTime>();
    
        static DelayedDelegate()
        {
    
            runDelegates = new Timer();
            runDelegates.Interval = 250;
            runDelegates.Tick += RunDelegates;
            runDelegates.Enabled = true;
    
        }
    
        public static void Add(MethodInvoker method, int delay)
        {
    
            delayedDelegates.Add(method, DateTime.Now + TimeSpan.FromSeconds(delay));
    
        }
    
        static void RunDelegates(object sender, EventArgs e)
        {
    
            List<MethodInvoker> removeDelegates = new List<MethodInvoker>();
    
            foreach (MethodInvoker method in delayedDelegates.Keys)
            {
    
                if (DateTime.Now >= delayedDelegates[method])
                {
                    method();
                    removeDelegates.Add(method);
                }
    
            }
    
            foreach (MethodInvoker method in removeDelegates)
            {
    
                delayedDelegates.Remove(method);
    
            }
    
    
        }
    
    }
