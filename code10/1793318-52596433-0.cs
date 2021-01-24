    private bool suppressTextChanged = false;
    private void TextBox_TextChanged(Object sender, TextChangedEventArgs e)
    {
        if (suppressTextChanged) return;
    
        var textBox = sender as TextBox;
        if(textBox != null)
        {
            int caretIndex = textBox.CaretIndex;
            string text = textBox.Text;
            int value;
            if(int.TryParse(text, out value))
            {
                if (text.Length > 2)
                {
                    text = text.Insert(2, ".");
    
                    suppressTextChanged = true;
                    textBox.Text = text;
                    if (caretIndex >= 2)
                        caretIndex++;
                    textBox.CaretIndex = caretIndex;
                    suppressTextChanged = false;
                }
            }
        }
    }
