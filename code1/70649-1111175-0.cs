    UpdateSourceTrigger old;
    protected override void OnGotFocus(RoutedEventArgs e)
    {
        Binding b = BindingOperations.GetBinding(textBox1, TextBox.TextProperty);
        old = b.UpdateSourceTrigger;
        b.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
    }
    protected override void OnLostFocus(RoutedEventArgs e)
    {
        Binding b = BindingOperations.GetBinding(textBox1, TextBox.TextProperty);
        b.UpdateSourceTrigger = old;
    }
