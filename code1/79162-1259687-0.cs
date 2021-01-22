    SqlConnection MSSQLConn = new SqlConnection("your connection string");
    MSSQLConn.Open();
    SqlCommand MSSQLSelectConsignment = new SqlCommand();
    MSSQLSelectConsignment.CommandText = "select * from yourtable where blah = @blah";
    MSSQLSelectConsignment.Parameters.AddWithValue("@blah", somestring);
    MSSQLSelectConsignment.Connection = MSSQLConnOLD;
    SqlDataReader reader = MSSQLSelectConsignment.ExecuteReader();
    
    while (reader.Read())
    {
    ...
    }
