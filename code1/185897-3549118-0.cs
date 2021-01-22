    textBox.KeyDown += OnTextBoxKeyDown;
    ...
    private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Tab)
            return;
    
        string tabReplacement = new string(' ', 4);
        string selectedTextReplacement = tabReplacement +
            textBox.SelectedText.Replace(Environment.NewLine, Environment.NewLine + tabReplacement);
    
        int selectionStart = textBox.SelectionStart;
        textBox.Text = textBox.Text.Remove(selectionStart, textBox.SelectionLength)
                                   .Insert(selectionStart, selectedTextReplacement);
            
        e.Handled = true; // to prevent loss of focus
    }
