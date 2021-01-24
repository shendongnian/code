    private void cboCustomerType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // A combobox with nothing selected will have a SelectedIndex of -1
        if (cboCustomerType.SelectedIndex > -1)
        {
            // Cast SelectedItem to DataRowView
            DataRowView item = cboCustomerType.SelectedItem as DataRowView;
            if (item != null)
            {
                // Access the data in column 1 of the selected row
                string value = item[1].ToString();
            }
        }
    }
