    private void txtExample_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Back && e.Key != Key.Enter)
        {
            double dblCostSqFt = 0;
            if (!double.TryParse(txtExample.Text, out dblCostSqFt))
            {
                MessageBox.Show("Error. You must enter valid numbers. Please correct.");
                txtExample.Select(0, txtExample.Text.Length);
            }
        }
    }
