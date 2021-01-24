    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
    
       if (!(sender is TextBox textBox))
       {
          return;
       }
    
       // use SelectionStart property to find the caret position
       // insert the previewed text into the existing text in the textbox
       var text = textBox.Text.Insert(textBox.SelectionStart, e.Text);
    
       if(text == "+" || text == "-")
          return;
             
       // if parsing is successful, set Handled to false
       e.Handled =  !double.TryParse(text, out var _) ;
    }
