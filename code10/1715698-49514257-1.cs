    private void OnTextReceived(string text)
    {
        txtOutput.Inlines.AddRange(Parse(text));
    }
    private void HandleCommand(string command)
    {
        MessageBox.Show("Command clicked: " + command);
    }
