    using System.Data;
    using System.Data.SqlClient;
    DataTable myDataTable;
    using (SqlConnection sqlConnection = new SqlConnection(.....)
    {
        using (SqlCommand sqlCommand = new SqlCommand())
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
    		
    		sqlCommand.Parameters.AddWithValue("@V0", values[0]);
    		sqlCommand.Parameters.AddWithValue("@V1", values[1]);
    		sqlCommand.Parameters.AddWithValue("@V2", values[2]);
    		sqlCommand.Parameters.AddWithValue("@V3", values[3);
    		sqlCommand.Parameters.AddWithValue("@V4", values[4]);
    		sqlCommand.Parameters.AddWithValue("@V5", values[5]);
    		sqlCommand.Parameters.AddWithValue("@V6", values[6]);
    		
            string queryStr = "INSERT INTO cibi ([nome], [Zuccheri_100g], [tipo], [Nome_EN], [Nome_DE],[Nome_ES], [DefaultAmt]) VALUES (@V0, @V1, @V2, @V3, @V4, @V5, @V6)";
    
            sqlCommand.CommandText = queryStr;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            myDataTable.Load(sqlDataReader);
            sqlConnection.Close();
        }
    }
