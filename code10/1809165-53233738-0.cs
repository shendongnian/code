    double dblCostSqFt = 0;
    if (!double.TryParse(txtCost.Text, out dblCostSqFt))
    {
        MessageBox.Show("Error. You must enter valid numbers. Please correct.");
        txtExample.Select(0, txtCost.Text.Length);
    }
