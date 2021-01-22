    this.rtb.CursorPositionChanged += 
        new System.EventHandler(this.rtb_CursorPositionChanged);
    this.rtb.SelectionChanged += 
        new System.EventHandler(this.rtb_SelectionChanged);
    .
    .
    .
    private void rtb_CursorPositionChanged(object sender, System.EventArgs e)
    {
        int line = rtb.CurrentLine;
        int col = rtb.CurrentColumn;
        int pos = rtb.CurrentPosition;
        
        statusBar.Text = "Line " + line + ", Col " + col + 
                         ", Position " + pos;
    }
    
    private void rtb_SelectionChanged(object sender, System.EventArgs e)
    {
        int start = rtb.SelectionStart;
        int end = rtb.SelectionEnd;
        int length = rtb.SelectionLength;
        
        statusBar.Text = "Start " + start + ", End " + end + 
                         ", Length " + length;
    }
