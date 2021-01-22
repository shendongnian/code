        Dim con As New SqlConnection(myconnectionstring)
        Dim com As New SqlCommand("TestDelay", con)
        com.CommandType = CommandType.StoredProcedure
        con.Open()
        Try
            com.ExecuteNonQuery()
        Catch ex As Exception
            con.Close()
            Response.Write(ex.Message)
        End Try
