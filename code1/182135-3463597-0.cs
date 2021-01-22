    public static class Extensions
    {
        public static void FastInvoke(this Dispatcher dispatcher, Action action)
        {
            if (dispatcher.CheckAccess())
                action.Invoke();
            else
                dispatcher.BeginInvoke(action);
        }
    }
