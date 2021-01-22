    // In your user control
    public class ValidationFailedEventArgs : EventArgs
    {
       public string Message { get; set; }
    }
    private EventHandler<ValidationFailedEventArgs> _validationFailed;
    public event EventHandler<ValidationFailedEventArgs> ValidationFailed
    {
       add { _validationFailed += value; }
       remove { _validationFailed -= value; }
    }
    public void OnValidationFailed(ValidationFailedEventArgs e)
    {
       if(_validationFailed != null)
          _validationFailed(this, e);
    }
    private void YourValidator()
    {
       if(!valid)
       {
          ValidationFailedEventArgs args = 
             new ValidationFailedEventArgs("Your Message");
          OnValidationFailed(args);
       }
    }
    // In your main form:
    userControl.ValidationFailed += 
       new EventHandler<ValidationFailedEventArgs>(userControl_ValidationFailed);
    
    // ...
    private void userControl_ValidationFailed(object sender, 
                                              ValidationFailedEventArgs e)
    {
       statusBar.Text = e.Message;
    }
