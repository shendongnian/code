    public List<ValidationError> MyErrors { get; private set; }
    
    private void Window_Error(object sender, 
        System.Windows.Controls.ValidationErrorEventArgs e)
    {
        if (e.Action == ValidationErrorEventAction.Added)
            MyErrors.Add(e.Error);
        else
            MyErrors.Remove(e.Error);
    }
