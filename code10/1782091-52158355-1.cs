    private void btnSearch_Click(object sender, EventArgs e)
    {
        lstCustomers.SelectedItems.Clear();
        int matchCount = 0;
        for (int i = lstCustomers.Items.Count - 1; i >= 0; i--)
        {
            if (lstCustomers.Items[i] is CustomersModel customer &&
                customer.Name.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) > -1)
            {
                matchCount++;
                lstCustomers.SetSelected(i, true);
            }         
        }
        lblItems.Text =  $"{matchCount} item{(matchCount > 1 ? "s" : "")} found";
    }
