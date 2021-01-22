    private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            BindingExpression b = MyTextBox.GetBindingExpression(TextBox.TextProperty); 
            if (b != null)
                b.UpdateSource();
            ICommand cmd = SomeButton.Command;
            if (cmd.CanExecute(null))
                cmd.Execute(null);
        }
    }
