    protected void OnEvent<T>(EventHandler<T> eventHandler, T args) where T : EventArgs
    {
        if (eventHandler == null) return;
        foreach (EventHandler<T> singleEvent in eventHandler.GetInvocationList())
        {
            if (singleEvent.Target != null && singleEvent.Target is ISynchronizeInvoke)
            {
                var target = (ISynchronizeInvoke)singleEvent.Target;
                if (target.InvokeRequired) {
                    target.BeginInvoke(singleEvent, new object[] { this, args });
                    continue;
                }
            }
            singleEvent(this, args);
        }
    }
