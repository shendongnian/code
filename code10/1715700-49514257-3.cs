    // Where you receive the text
    // This probably is just a `txtOutput.Text += ` until now
    private void OnTextReceived(string text)
    {
        txtOutput.Inlines.AddRange(Parse(text));
    }
    // the method that gets invoked when a link is clicked
    // and you can parse/handle the actual command
    private void HandleCommand(string command)
    {
        MessageBox.Show("Command clicked: " + command);
    }
