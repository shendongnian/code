    var element = yourRunTimeControl as DependencyObject;
    System.Windows.Controls.Validation.AddErrorHandler(element, ErrorHandler)
    private void ErrorHandler(object sender, System.Windows.Controls.ValidationErrorEventArgs e)
    {
        ...
    }
