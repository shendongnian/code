    if (string.IsNullOrWhiteSpace(txtUnitName.Text) 
     || string.IsNullOrWhiteSpace(txtAlias.Text))
    {
        MessageBox.Show("Unit Name and Alias are mandatory!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
