    public void LogTextEvent(RichTextBox TextEventLog, Color TextColor, string EventText)
    {
        if (TextEventLog.InvokeRequired)
        {
            TextEventLog.BeginInvoke(new Action(delegate {
                LogTextEvent(TextEventLog, TextColor, EventText);
            }));
            return;
        }
        string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";
        // color text.
        TextEventLog.SelectionStart = TextEventLog.Text.Length;
        TextEventLog.SelectionColor = TextColor;
        // newline if first line, append if else.
        if (TextEventLog.Lines.Length == 0)
        {
            TextEventLog.AppendText(nDateTime + EventText);
            TextEventLog.ScrollToCaret();
            TextEventLog.AppendText(System.Environment.NewLine);
        }
        else
        {
            TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
            TextEventLog.ScrollToCaret();
        }
    }
