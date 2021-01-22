    private void onlyNumeric(object sender, TextCompositionEventArgs e)
    {
        string onlyNumeric = @"^([0-9]+(.[0-9]+)?)$";
        Regex regex = new Regex(onlyNumeric);
        e.Handled = !regex.IsMatch(e.Text);
    }
