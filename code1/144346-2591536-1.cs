    protected override void OnTextInput(System.Windows.Input.TextCompositionEventArgs e)
    {    
        char newChar = Convert.ToChar(e.Text);        
        if (!Char.IsDigit(newChar)) e.Handled = true; 
    }
