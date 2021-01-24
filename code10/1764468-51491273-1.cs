    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        checkboxlincense.IsChecked = true;
        License_agreement();
    }
    private void License_agreement()
    {
        updatebutton.Enabled = checkboxlincense.IsChecked;
    }
