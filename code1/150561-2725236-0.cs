    SqlConnection conn = new SqlConnexion(connection_string);
    SqlCommand cmd = new SqlCommand("INSERT INTO #tmp0 (code) VALUE (@code)", conn);
    conn.Open();
    foreach (string s in bigListOfCodes)
    {
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@code", s);
        cmd.ExecuteNonQuery();
    }
    cmd = new SqlCommand("SELECT * FROM tbl " + 
              "WHERE code IN (SELECT CODE FROM #tmp0)", conn);
    
    SqlDataReader rs = cmd.ExecuteReader();
    while (rs.Read())
    {
        /* do stuff */
    }
    cmd = new SqlCommand("DROP TABLE #tmp0", conn);
    cmd.ExecuteNonQuery();
    conn.Close();
