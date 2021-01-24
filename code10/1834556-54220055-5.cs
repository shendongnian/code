    private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
        if (double.TryParse(Feet.Text, out feet))
            meters = feet / 3.281d;
        else
            MessageBox.Show($"You've entered an invalid value: {Feet.Text}.");
    }
