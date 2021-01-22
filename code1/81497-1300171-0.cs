    Public Sub RunFunction(ByVal input As Short)
                Dim sqlParams(1) As Data.SqlClient.SqlParameter
                Using myConnection As New Data.SqlClient.SqlConnection
                    Using myCommand As New Data.SqlClient.SqlCommand("Select * FROM dbo.MyFunction(@MyParam)", myConnection)
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
