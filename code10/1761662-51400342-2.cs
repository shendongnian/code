    public List<Customer> GetCustomers()
    {
        var customers = new List<Customer>();
        try
        {
            string sqlqry = "SELECT ID, Name, Value FROM Customer";
            SqlCommand cmds = new SqlCommand(sqlqry, _con); // here _con is your predefined SqlConnection object
            SqlDataReader dr = cmds.ExecuteReader();
            while (dr.Read())
            {
                customers.Add(new Customer
                {
                    ID = (int)dr["ID"],
                    Nmae = dr["Name"].ToString(),
                    Value = dr["Value"].ToString(),
                });
            }
        }
        catch (Exception ex)
        {
            // Handle exception here
        }
        return customers;
    }
