    private void frmSalesAdd_Load(object sender, EventArgs e)
    {
        string selectQuery;
        selectCustomers = "SELECT * FROM Customers";
        selectProducts = "SELECT * FROM Products";**
        SqlConnection conn = ConnectionManager.DatabaseConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand(selectCustomers, conn);
        using(SqlDataReader rdr = cmd.ExecuteReader()) {
            while (rdr.Read())
            {
                lbCustomerID.Items.Add(rdr["CustomerID"].ToString());
                cbCustomer.Items.Add(rdr["LastName" ].ToString());
            }
        }
        cmd = new SqlCommand(selectProducts, conn);
        using(SqlDataReader rdr = cmd.ExecuteReader()) {
            while (rdr.Read())
            {
                lbProductID.Items.Add(rdr["ProductID"].ToString());
                cbProduct.Items.Add(rdr["Product"].ToString());
            }
        }
    }
