    public static class Extensions
    {
        // Extension method which marshals events back onto the main thread
        public static void Raise(this MulticastDelegate multicast, object sender, EventArgs args)
        {
            foreach (Delegate del in multicast.GetInvocationList())
            {
                // Try for WPF first
                DispatcherObject dispatcherTarget = del.Target as DispatcherObject;
                if (dispatcherTarget != null && !dispatcherTarget.Dispatcher.CheckAccess())
                {
                    // WPF target which requires marshaling
                    dispatcherTarget.Dispatcher.BeginInvoke(del, sender, args);
                }
                else
                {
                    // Maybe its WinForms?
                    ISynchronizeInvoke syncTarget = del.Target as ISynchronizeInvoke;
                    if (syncTarget != null && syncTarget.InvokeRequired)
                    {
                        // WinForms target which requires marshaling
                        syncTarget.BeginInvoke(del, new object[] { sender, args });
                    }
                    else
                    {
                        // Just do it.
                        del.DynamicInvoke(sender, args);
                    }
                }
            }
        }
        // Extension method which marshals actions back onto the main thread
        public static void Raise<T>(this Action<T> action, T args)
        {
            // Try for WPF first
            DispatcherObject dispatcherTarget = action.Target as DispatcherObject;
            if (dispatcherTarget != null && !dispatcherTarget.Dispatcher.CheckAccess())
            {
                // WPF target which requires marshaling
                dispatcherTarget.Dispatcher.BeginInvoke(action, args);
            }
            else
            {
                // Maybe its WinForms?
                ISynchronizeInvoke syncTarget = action.Target as ISynchronizeInvoke;
                if (syncTarget != null && syncTarget.InvokeRequired)
                {
                    // WinForms target which requires marshaling
                    syncTarget.BeginInvoke(action, new object[] { args });
                }
                else
                {
                    // Just do it.
                    action.DynamicInvoke(args);
                }
            }
        }
    }
  
