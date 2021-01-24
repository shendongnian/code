    private void customer_IsCheckedChanged(object sender, EventArgs e)
    {
        if (customer.IsChecked)
        {
            business.IsChecked = false;
        }
    }
    private void business_IsCheckedChanged(object sender, EventArgs e)
    {
        if (business.IsChecked)
        {
            customer.IsChecked = false;
        }
    }
