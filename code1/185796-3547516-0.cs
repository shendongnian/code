    SqlConnection conn = new SqlConnection("CONNECTION_STRING");
    conn.Open;
    
    SqlCommand comm = conn.CreateCommand();
    comm.CommandText = "SELECT * from Table";
    
    SqlDataAdapter da = new SqlDataAdapter(comm);
    DataTable table = new DataTable();
    
    da.Fill(table); // Here is equivalent with getRows()
