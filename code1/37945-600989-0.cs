    SqlConnection conn = new SqlConnection(connString);
    SqlCommand cmnd = new SqlCommand("Insert Into Table (P1, P2) Values (@P1, @P2)", conn);
    cmnd.Parameters.AddWithValue("@P1", P1Value);
    cmnd.Parameters.AddWithValue("@P2", P2Value);
    cmnd.ExecuteNonQuery();
    conn.Close();
