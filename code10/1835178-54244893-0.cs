    private void customer_IsCheckedChanged(object sender, EventArgs e)
    {
        if (business.IsChecked == true)
        {
            business.IsChecked = !customer.IsChecked;
        }
        if (business.IsChecked == false)
        {
            business.IsChecked = !customer.IsChecked;
        }
    }
