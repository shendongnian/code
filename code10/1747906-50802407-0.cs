    private void Movement(object sender, EventArgs e)
    {
        if (InvokeRequired)
        {
            // Oops, we're not on the UI thread. Invoke on the UI thread.
            this.Invoke(new Action<object, EventArgs>(Movement), new object[] { sender, e });
            ... nasty exceptions happen if you try and update UI controls on a non-UI thread
        }
        else
        {
            // Now we're on the UI thread
            UpdateData(sender);
            ... clear to interact with UI controls.
        }
    }
