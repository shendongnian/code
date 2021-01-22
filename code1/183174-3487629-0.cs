    using (SqlConnection connection = new SqlConnection("Put your ConnectionString here"))
    {
    	connection.Open();
        using (SqlDataAdapter adapter = new SqlDataAdapter("My SQL from Above", connection))
        {
         	DataTable table = new DataTable();
             adapter.Fill(table);
             // now you can do here what ever you like with the table...
    
    	     foreach(DataRow row in table.Rows)
             {
            	if (row.IsNull("Text") == false)
                   Console.WriteLine(row["Text"].ToString());
    	     }
    	}
    }
