    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string str = ((TextBox)sender).Text + e.Text;
        decimal i;
        e.Handled = !decimal.TryParse(str, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out i);
    }
