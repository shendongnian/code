    public static RichTextBox RichTextBoxChangeWordColor(ref RichTextBox rtb, string startWord, string endWord, Color color)
    {
        rtb.SuspendLayout();
        int slct = rtb.SelectionIndent;
        int ss = rtb.SelectionStart;
        List<Point> ls = MiMFa_StringService.GetAllWordsIndecesBetween(rtb.Text, startWord, endWord, true);
        foreach (var item in ls)
        {
            rtb.SelectionStart = item.X;
            rtb.SelectionLength = item.Y - item.X;
            rtb.SelectionColor = color;
        }
        rtb.SelectionStart = ss;
        rtb.SelectionIndent = slct;
        rtb.ResumeLayout(true);
        return rtb;
    }
