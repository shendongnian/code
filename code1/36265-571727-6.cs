    static void SynchronizedInvoke(ISynchronizeInvoke sync, Action action)
    {
        // If the invoke is not required, then invoke here and get out.
        if (!sync.InvokeRequired)
        {
            // Execute action.
            action();
    
            // Get out.
            return;
        }
    
        // Marshal to the required context.
        sync.Invoke(action, new object[] { });
    }
