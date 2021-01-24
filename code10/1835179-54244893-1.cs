    private void customer_IsCheckedChanged(object sender, EventArgs e)
    {
        if(customer.IsChecked)
            business.IsChecked = false;
    }
