    private void btnsubtract_Click(object sender, RoutedEventArgs e)
    {
        num01 = Convert.ToDouble(txtcalcdisplay.Text);
        txtcalcdisplay.Text = "";
        operater = 1;  // <-- change this line to be like this, removed the single quotes
    }
