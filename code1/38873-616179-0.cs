    public static class ControlInvokeExtensions
    {
        public static void InvokeOnHostThread(Control host, MethodInvoker method)
        {
            if (IsHandleCreated)
                Invoke(new EventHandler(delegate { method(); }));
            else
                method();
        }
    }
