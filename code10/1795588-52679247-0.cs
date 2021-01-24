    private void btnFind_Click(object sender, RoutedEventArgs e)
    {
        Customer customer = store.find(Int32.Parse(txtID.Text));
        ClearCustomerFields();
        if (customer != null)
        {
            FillCustomerFields(customer);
        }
    }
    private void ClearCustomerFields()
    {
        txtID.Text = "";
        txtName.Text = "";
    }
    private void FillCustomerFields(Customer customer)
    {
        txtID.Text = customer.ID.ToString();
        txtName.Text = customer.Name;
    }
