    public void AppendText(string text, Color color, bool addNewLine = false)
    {
    		box.SuspendLayout();
    		box.SelectionColor = color;
    		box.AppendText(addNewLine
    			? $"{text}{Environment.NewLine}"
    			: text);
    		box.ScrollToCaret();
    		box.ResumeLayout();
    }
