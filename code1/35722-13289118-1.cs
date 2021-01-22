    private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            TextBox tBox = (TextBox)sender;
            DependencyProperty prop = TextBox.TextProperty;
            
            BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
            if (binding != null) { binding.UpdateSource(); }
        }
    }
