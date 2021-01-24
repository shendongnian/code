    private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            DatePicker dp = (DatePicker)sender;
            Regex regex = new Regex("[^0-9/]"); //regex that matches allowed text
            e.Handled = regex.IsMatch(e.Text);
           
        }
