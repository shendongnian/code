    <%
        using(SqlConnection conn = new SqlConnection(someConnectionString))
        {
            SqlCommand command = new SqlCommand("select * from table", conn);
         
            DataTable results = new DataTable();
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
    
            conn.Open();
     
            adapter.Fill(results, command);
        }
    
        // You can work with the rows in the DataTable here
    %>
