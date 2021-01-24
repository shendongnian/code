    private void PasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[0-9]+");
        if (!regex.IsMatch(e.Text))
        {
            e.Handled = true;
        }
    }
