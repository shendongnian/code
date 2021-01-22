    delegate void UpdateLabelDelegate (string message);
    void UpdateLabel (string message)
    {
        if (InvokeRequired)
        {
             Invoke (new UpdateLabelDelegate (UpdateLabel), message);
             return;
        }
        MyLabelControl.Text = message;
    }
