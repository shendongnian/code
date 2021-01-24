    private void txtSearchAdmin_TextChanged(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(txtSearchAdmin.Text))
                    dataGridView.DataSource = employeesBindingSource;
                else
                {
                    var query = from o in this.adminData.Employees
                                where o.Customer_Name.Contains(txtSearchAdmin.Text) || o.Phone == txtSearchAdmin.Text || o.Address.Contains(txtSearchAdmin.Text)
                                select o;
                    dataGridView.DataSource = query.ToList();
              }
            
    }
