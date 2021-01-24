    private void btnCalc_Click(object sender, EventArgs e)
    {
        if (GetDoubleFromTextBox(tbxHours, out double hours) && 
            GetDoubleFromTextBox(tbxPay, out double pay))
        {
            double result = hours * pay;
            MessageBox.Show($" total amount is {result} ", "Click Event", 
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
    public bool GetDoubleFromTextBox(TextBox control, out double value)
    {
        if (!double.TryParse(control.Text, out value))
        {
            MessageBox.Show($"You must enter a number in {control.Name}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            control.Clear();
            return false;
        }
        return true;
    }
