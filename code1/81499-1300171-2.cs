    Public Sub RunFunction(ByVal input As Short)
                Using myConnection As New Data.SqlClient.SqlConnection
                    Using myCommand As New Data.SqlClient.SqlCommand("Select dbo.MyFunction(@MyParam)", myConnection)
                        myCommand.CommandType = CommandType.Text
                        myCommand.Parameters.Add(New Data.SqlClient.SqlParameter("@MyParam", input))
                        myCommand.CommandTimeout = 0
                        Try
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
    
                        End Try
                    End Using
    
                End Using
            End Sub
