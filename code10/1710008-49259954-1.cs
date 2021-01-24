    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       using (SqlCommand cmd1= new SqlCommand(query1, connection))
       {
       }
    
       using (SqlCommand cmd2= new SqlCommand(query2, connection))
       {
       }  
    }
