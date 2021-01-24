    private void txtExample_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Enter)
        {
            double dblCostSqFt = 0;
            if (!double.TryParse(txtExample.Text, out dblCostSqFt))
            {
                MessageBox.Show("Error. You must enter valid numbers. Please correct.");
                txtExample.Select();
            }
        }
    }
