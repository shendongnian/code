    public static class Extensions
    {
        public static void Execute(this ISynchronizeInvoke invoker,
                                   MethodInvoker action)
        {
            if (invoker.InvokeRequired)
            {
                 invoker.BeginInvoke(action);
            }
            else
            {
                 action();
            }
        }
    }
