    Using SqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbConnect3").ConnectionString)
        SqlConn.Open()
        Using cmd As New SqlCommand("CountUsers", SqlConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@cacLogin", "MAULDIN.THOMAS.C.12345")
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery();
        End Using
    End Using
