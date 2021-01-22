    public void InvokeExample()
    {
        if (InvokeRequired)
        {
            // Invoke this method on the UI thread using an anonymous delegate
            Invoke(new MethodInvoker(() => InvokeExample()));
            return;
        }
    
        string header = Control.Header;
    }
