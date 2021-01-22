    private void textBoxNumeric_TextChanged(object sender, TextChangedEventArgs e) 
    {         
          TextBox textBox = sender as TextBox;         
          Int32 selectionStart = textBox.SelectionStart;         
          Int32 selectionLength = textBox.SelectionLength;         
          String newText = String.Empty;         
          int count = 0;         
          foreach (Char c in textBox.Text.ToCharArray())         
          {             
             if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))             
             {                 
                newText += c;                 
                if (c == '.')                     
                  count += 1;             
             }         
         }         
         textBox.Text = newText;         
         textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart :        textBox.Text.Length;     
    } 
