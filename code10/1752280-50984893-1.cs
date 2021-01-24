    private void txtdiscount_SelectionChanged(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(txtdiscount.Text))
            {
                string dis = txtdiscount.Text;
                double isid = double.Parse(dis);
                isid = isid + 10;
                MessageBox.Show(isid.ToString());
            }
        }
        catch (Exception exp)
        {
            MessageBox.Show(exp.ToString());
        }
    }
