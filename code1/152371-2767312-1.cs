    void SetToEndOfLine(TextBox tb, int line)
    {
       int loc = 0;
       for (int x = 0; x < tb.Lines.Length && tb <= line; x++)
       {
          loc += tb.Lines[x].Length;
       }
       tb.SelectionStart = loc;
    }
