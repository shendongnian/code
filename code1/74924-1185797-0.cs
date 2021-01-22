    using(var con = new SqlConnection("ConnectionString"))
    {
        using (var cmd = con.CreateCommand())
        {
            // This Example uses a parameterized SQL statement
            // but you can also use SQL Server stored procedures
            cmd.CommandText = "UPDATE table SET field1 = @field1, field2 = @field2 WHERE id = @id"; // etc, etc    
            cmd.CommandType = CommandType.Text;
            // Add values for the parameter values for the 
            // parameter placeholders in the SQL statement
            cmd.Parameters.AddWithValue("field1", Textbox1.Text);
            cmd.Parameters.AddWithValue("field2", Textbox2.Text);  
            cmd.Parameters.AddWithValue("id", myObject.Id);                
            
            con.Open();
 
            // You might want to use ExecuteScalar instead and get a return value back
            // from the database to signal success
            cmd.ExecuteNonQuery();           
        }
    }
