    // using usings :-)
    using (var connection = new SqlConnection(connectionstring))
    using (var command1 = connection.CreateCommand())
    {
         command1.CommandType = CommandType.Text;
       
         // your query with parameter: @qty
         // note 
         command1.CommandText = "update product set product_qty -=@qty";
     
         // setting a type: aka VarChar, Int etc, will make sure you 
         // don't mix up all the ' and "'s
         command1.Parameters.Add("@qty", SqlDbType.Int);
        
         // set parameter value: all values are safe.
         // since you are using an int, make sure you put in an int.
         // [note] int.Parse("some text other than a number like 3") 
         // will throw an exception
         command1.Parameters["@qty"].Value = int.Parse(t1.Text);
     
         // execute
         command1.ExecuteNonQuery();
    }
