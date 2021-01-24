    public static Product GetProduct(string code)
    {        
        try
        {                        
            SqlConnection connection = Connection.GetConnection();
            string select = @"SELECT ProductCode, Description, UnitPrice " + 
                "FROM Products WHERE ProductCode = @ProductCode";
            SqlCommand selectCommand = new SqlCommand(select, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", code);
            connection.Open();
            SqlDataReader prodReader = 
                selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (prodReader.Read())
            {
                return new Product
                {
                    Code = prodReader["ProductCode"].ToString(),
                    Description = prodReader["Description"].ToString(),
                    Price = (decimal) prodReader["UnitPrice"]
                };
            }
            else
            {
                return null;
            }
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
    }
