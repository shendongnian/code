    public static class CrossThreadHelper
    {
        public static bool InvokeHelper<T>(this ISynchronizeInvoke value, EventHandler<T> method, object sender, EventArgs e)
        where T : EventArgs
        {
            return value.InvokeCrossThread(method, new object[] { sender, e });
        }
        public static bool InvokeHelper(this ISynchronizeInvoke value, Delegate method, object[] args)
        {
            return value.InvokeCrossThread(method, args);
        }
        public static bool InvokeHelper(this ISynchronizeInvoke value, Delegate method, object sender, EventArgs e)
        {
            return value.InvokeCrossThread(method, new object[] { sender, e });
        }
        public static bool InvokeHelper(this ISynchronizeInvoke value, EventHandler method)
        {
            return value.InvokeCrossThread((Delegate)method, new object[] { null, null });
        }
        public static bool InvokeHelper(this ISynchronizeInvoke value, EventHandler method, object sender, EventArgs e)
        {
            return value.InvokeCrossThread((Delegate)method, new object[] { sender, e });
        }
        public static bool InvokeCrossThread(this ISynchronizeInvoke value, Delegate method, object[] args)
        {
            if (value.InvokeRequired)
            {
                value.BeginInvoke(method, args);
            }
            return value.InvokeRequired;
        }
    }
