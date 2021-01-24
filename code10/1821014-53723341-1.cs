    private void CopyTextBox(object sender, MouseButtonEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            Clipboard.SetText(textBox.Text);
            (textBox.ToolTip as ToolTip).IsOpen = false;
            (textBox.ToolTip as ToolTip).IsOpen = true;
        }
    }
