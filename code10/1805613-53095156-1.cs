    public partial clas xxxViewController:UIViewController,IUITextFieldDelegate
    txtTo.WeakDelegate=this;
    
    [Export("textFieldDidBeginEditing:")]
    public void EditingStarted(UITextField textField)
    {
      NSRange range = new NSRange(index, 0);
      UITextPosition start = textField.GetPosition(textField.BeginningOfDocument, range.Location);
      UITextPosition end = textField.GetPosition(start, range.Length);
      textField.SelectedTextRange = textField.GetTextRange(start, end);
    } 
