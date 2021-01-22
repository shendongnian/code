    private void SetText(Control c, string newText)
    {
        if (c.InvokeRequired)
            c.Invoke(new Action<int>((x) => c.Text = x), newText);
        else
            c.Text = newText; 
    }
