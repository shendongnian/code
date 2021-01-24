    if (!double.TryParse(txtCost.Text, out var dblCostSqFt))
    {
        MessageBox.Show("Error. You must enter valid numbers. Please correct.");
        txtExample.Select(0, txtCost.Text.Length);
        return;
    }
