    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if ((e.KeyCode >= Keys.Left & e.KeyCode <= Keys.Down)) return;
        if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey) return;
        int CurrentPosition = richTextBox1.SelectionStart;
        int[] WordStartEnd;
        string word = GetWordFromPosition(richTextBox1, CurrentPosition - 1, out WordStartEnd);
        ColoredWord result = ColoredWords.FirstOrDefault(s => s.Word == word.ToUpper());
        SetSelectionColor(richTextBox1, result, CurrentPosition, WordStartEnd);
        if (e.KeyCode == Keys.Space && result == null) 
        {
            word = GetWordFromPosition(richTextBox1, CurrentPosition + 1, out WordStartEnd);
            result = ColoredWords.FirstOrDefault(s => s.Word == word.ToUpper());
            SetSelectionColor(richTextBox1, result, CurrentPosition, WordStartEnd);
        }
    }
