    public static class UIThread
    {
        private static readonly Dispatcher Dispatcher;
        static UIThread()
        {
            // Store a reference to the current Dispatcher once per application
            Dispatcher = Deployment.Current.Dispatcher;
        }
        /// <summary>
        ///   Invokes the given action on the UI thread - if the current thread is the UI thread this will just invoke the action directly on
        ///   the current thread so it can be safely called without the calling method being aware of which thread it is on.
        /// </summary>
        public static void Invoke(Action action)
        {
            if (Dispatcher.CheckAccess())
                action.Invoke();
            else
                Dispatcher.BeginInvoke(action);
        }
    }
