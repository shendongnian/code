    //using usings :-)
    using (var connection = new SqlConnection(connectionstring))
    using (var command1 = connection.CreateCommand())
    {
         command1.CommandType = CommandType.Text;
       
         //your query with parameter
         command1.CommandText = "update product set product_qty=@qty";
     
         command1.Parameters.Add("@qty", SqlDbType.VarChar,100);
         //set parameter value: all values are safe.
         command1.Parameters["@qty"].Value = "product_qty-" + t1.Text;
     
         //execute
         command1.ExecuteNonQuery();
    }
