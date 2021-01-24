    public void GetCustomer() {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("DataConnection"))) {
                    SqlCommand command = new SqlCommand(Helper.Procedure("Customer"), connection);
    
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Action", "Retrieve");
                    command.Parameters.AddWithValue("@name", this.customer_name);
    
                    connection.Open();
    
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            this.tbl_id = (int)reader["tbl_id"];
                            this.customer_name = (string)reader["customer_name"];
                            this.customer_id = reader.GetInt32(customer_id);
                            this.customer_address = (string)reader["customer_address"];
                            this.customer_city = (string)reader["customer_city"];
                            this.customer_state = (string)reader["customer_state"];
                            this.customer_zip = reader.GetInt32(customer_zip);
                        }
                    }
