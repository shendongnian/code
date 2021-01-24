    public Customer Add(Customer customer)
        {
            string query = "INSERT INTO Customer(Name,Address) OUTPUT INSERTED.ID VALUES (@Name,@Address)";
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    con.Open();
                    customer.CustomerID = (int)cmd.ExecuteScalar();
                    con.Close();
                }
                return customer;
            }
        }
