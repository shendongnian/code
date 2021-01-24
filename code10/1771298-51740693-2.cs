    public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (searchTextBox.Text == result)
            next.IsEnabled = false;
    }
