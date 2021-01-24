    string sqlQuery = "SELECT * FROM Mavads INNER JOIN OtherTable ON Mavads.CD = OtherTable.AB;"
    using (SqlConnection sqlConnection = new SqlConnection("YourConnectionString"))
    {
    	SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
        sqlConnection.Open();
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
    
        while (sqlReader.Read())
        {
            comboBox.Items.Add(sqlReader["name"].ToString());
        }
    
        sqlReader.Close();
    }
