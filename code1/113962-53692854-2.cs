    public static RichTextBox RichTextBoxChangeWordColor(ref RichTextBox rtb, string startWord, string endWord, Color color)
    {
        rtb.SuspendLayout();
        Point scroll = rtb.AutoScrollOffset;
        int slct = rtb.SelectionIndent;
        int ss = rtb.SelectionStart;
        List<Point> ls = GetAllWordsIndecesBetween(rtb.Text, startWord, endWord, true);
        foreach (var item in ls)
        {
            rtb.SelectionStart = item.X;
            rtb.SelectionLength = item.Y - item.X;
            rtb.SelectionColor = color;
        }
        rtb.SelectionStart = ss;
        rtb.SelectionIndent = slct;
        rtb.AutoScrollOffset = scroll;
        rtb.ResumeLayout(true);
        return rtb;
    }
    public static List<Point> GetAllWordsIndecesBetween(string intoText, string fromThis, string toThis,bool withSigns = true)
    {
        List<Point> result = new List<Point>();
        Stack<int> stack = new Stack<int>();
        bool start = false;
        for (int i = 0; i < intoText.Length; i++)
        {
            string ssubstr = intoText.Substring(i);
            if (ssubstr.StartsWith(fromThis) && ((fromThis == toThis && !start) || !ssubstr.StartsWith(toThis)))
            {
                if (!withSigns) i += fromThis.Length;
                start = true;
                stack.Push(i);
            }
            else if (ssubstr.StartsWith(toThis) )
            {
                if (withSigns) i += toThis.Length;
                start = false;
                if (stack.Count > 0)
                {
                    int startindex = stack.Pop();
                    result.Add(new Point(startindex,i));
                }
            }
        }
        return result;
    }
