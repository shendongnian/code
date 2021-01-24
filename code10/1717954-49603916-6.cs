    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*[.,]?[0-9]+$");
        // if its not matched then Handle the event
        // so it never gets to the display
        e.Handled = !regex.IsMatch(e.Text);
    }
