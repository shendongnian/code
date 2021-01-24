    private void CopyTextBox(object sender, MouseButtonEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            Clipboard.SetText(textBox.Text);
            ((ToolTip)textBox.ToolTip).IsOpen = false;
            ((ToolTip)textBox.ToolTip).IsOpen = true;
        }
    }
