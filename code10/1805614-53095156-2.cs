    //...
    this.PerformSelector(new Selector("MoveCursorPosition:"),txtTo,0.1);
    //...
    [Export("MoveCursorPosition:")]
    public void MoveCursorPosition(UITextField textField)
    {
      NSRange range = new NSRange(index, 0);
      UITextPosition start = textField.GetPosition(textField.BeginningOfDocument, range.Location);
      UITextPosition end = textField.GetPosition(start, range.Length);
      textField.SelectedTextRange = textField.GetTextRange(start, end);
    }
