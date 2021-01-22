    private void DeleteLine(int a_line)
    {
        int start_index = richTextBox.GetFirstCharIndexFromLine(a_line);
        int count = richTextBox.Lines[a_line].Length;
    
        // Eat new line chars
        if (a_line < richTextBox.Lines.Length - 1)
        {
            count += richTextBox.GetFirstCharIndexFromLine(a_line + 1) -
                ((start_index + count - 1) + 1);
        }
    
        richTextBox.Text = richTextBox.Text.Remove(start_index, count);
    }
