        private void txtCustomerNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            fillCustomerListDataContext dbC = new fillCustomerListDataContext();
            
            var fillCustList = from c in dbC.lstCustomers
                               where c.CustomerName.StartsWith(txtCustomerNameSearch.Text)
                               orderby c.CustomerName
                               select new
                               {
                                   c.CustomerName,
                                   c.CustomerID
                               };
           
            try
            {
                lstCustomerNames.ItemsSource = fillCustList;
                lstCustomerNames.DisplayMemberPath = "CustomerName";
                lstCustomerNames.SelectedItem = "CustomerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error = " + ex.Message,"Keeping Amy off balance message");
            }
        }
