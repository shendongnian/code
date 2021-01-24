    private void Box1_TextChanged(object sender, TextChangedEventArgs e)
    {
        RichTextBox textBox = sender as RichTextBox;
        var text = new TextRange(textBox.Document.ContentStart, textbox.Document.ContentEnd).Text;
        
        if (IsValid(text))
        {
            Dispatcher.BeginInvoke((Action)ChangeFocus);
        }
    }
    private void ChangeFocus()
    {
        Box2.Focus();
    }
    private bool IsValid(string text)
    {
        var plainText = text.Substring(0, text.Length - 2);
   
        if (plainText == "hello world")
            return true;
        
        return false;
    }
