    private void update()
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(() => { update(); }));
        }
        else
        {
            // Do the update.
        }
    }
