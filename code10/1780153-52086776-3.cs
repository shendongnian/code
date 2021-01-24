    private void btnCalc_Click(object sender, EventArgs e)
    {
        if (TryParseFromTextBox(tbxHours, out double hours) && 
            TryParseFromTextBox(tbxPay, out double pay))
        {
            double result = hours * pay;
            MessageBox.Show($" total amount is {result} ", "Click Event", 
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
    public bool TryParseFromTextBox(TextBox control, out double value)
    {
        if (!double.TryParse(control.Text, out value))
        {
            MessageBox.Show($"You must enter a number in {control.Name}", "Input Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            control.Clear();
            return false;
        }
        return true;
    }
