    private static void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        var command = GetTextUpdateCommandProperty(textBox);
        if (command != null)
             command.Execute(null);
    }
