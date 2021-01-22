    private void FireEventAppender_OnMessageLogged(object sender, MessageLoggedEventArgs e)
    {
        DisplayStatusUpdate(e.LoggingEvent.RenderedMessage);
    }
    private delegate void DisplayStatusUpdateDelegate(string text);
    private void DisplayStatusUpdate(string text)
    {
         if(InvokeRequired)
             this.Invoke(new DisplayStatusUpdateDelegate(DisplayStatusUpdate), text);
         else
         {
             _StatusTextBox.Text = _StatusTextBox.Text + text;
             _StatusTextBox.Text = String.Format("{0}\r\n", _StatusTextBox.Text);
             _StatusTextBox.SelectionStart = _StatusTextBox.Text.Length - 1;
             _StatusTextBox.ScrollToCaret();
         }
    }
