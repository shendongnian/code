    private void UpdateText(string text)
    {
        // Check for cross thread violation, and deal with it if necessary
        if (InvokeRequired)
        {
            Invoke(new Action<string>(UpdateText), new[] {text});
            return;
        }
        // What the update of the UI
        p.label1.Text = text;
    }
    public static void Dummy(........)
    {
       UpdateText("New text");
    }
