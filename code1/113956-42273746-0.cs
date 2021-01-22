    public void AppendText(string text, Color color, bool AddNewLine = false)
    {
    		box.SuspendLayout();
    		box.SelectionColor = color;
    		box.AppendText(AddNewLine
    			? $"{text}{Environment.NewLine}"
    			: text);
    		box.ScrollToCaret();
    		box.ResumeLayout();
    }
