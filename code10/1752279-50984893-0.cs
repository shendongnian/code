    private void txtdiscount_SelectionChanged(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(txtdiscount.Text.ToString()))
            {
                string dis = txtdiscount.Text.ToString();
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
