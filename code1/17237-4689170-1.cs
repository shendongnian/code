    public static class InvokeExtensions
    {
        public static void InvokeHandler(this Control control, MethodInvoker del) // Sync. control-invoke extension.
        {
            if (control.InvokeRequired)
            {
                control.Invoke(del);
                return; 
            }
            del(); // run the actual code.
        }
    
        public static void AsyncInvokeHandler(this Control control, MethodInvoker del) // Async. control-invoke extension.
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(del);
                return; 
            }
            del(); // run the actual code.
        }
    }
