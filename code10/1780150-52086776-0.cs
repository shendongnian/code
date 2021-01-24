    private void btnCalc_Click(object sender, EventArgs e)
    {
        if (GetValueFromTextBox(tbxHours, out double hours) && GetValueFromTextBox(tbxPay, out double pay))
        {
            // multiply
        }
    }
    public bool GetValueFromTextBox(TextBox control, out double value)
    {
        if (!double.TryParse(control.Text, out value))
        {
            MessageBox.Show($"You must enter a number in {control.Name}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            control.Clear();
            return false;
        }
        return true;
    }
