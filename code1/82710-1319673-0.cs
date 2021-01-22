    private void DisplayStatusUpdate(string text)
    {
        this.Invoke(new MethodInvoker(() => 
        {
             _StatusTextBox.Text = _StatusTextBox.Text + text;
             _StatusTextBox.Text = String.Format("{0}\r\n", _StatusTextBox.Text);
             _StatusTextBox.SelectionStart = _StatusTextBox.Text.Length - 1;
             _StatusTextBox.ScrollToCaret();
        }));
    }
