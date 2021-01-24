    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MultiBindingExpression multiBindingExpression;
    
        foreach (TextBox textBox in FindVisualChildren<TextBox>(this))
        {
            multiBindingExpression = BindingOperations.GetMultiBindingExpression(textBox, TextBox.BackgroundProperty);
            multiBindingExpression.UpdateTarget();
        }
    }
