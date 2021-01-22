     Partial Public Class MyDataAdapter
        Public Function GetList() As System.Collections.Generic.List(Of System.Int32)
            Dim list As New System.Collections.Generic.List(Of System.Int32)
            Dim command As System.Data.SqlClient.SqlCommand = Me.CommandCollection(0)
            Dim previousConnectionState As System.Data.ConnectionState = command.Connection.State
            Try
                If ((command.Connection.State And System.Data.ConnectionState.Open) _
                            <> System.Data.ConnectionState.Open) Then
                    command.Connection.Open()
                End If
                Using reader As System.Data.SqlClient.SqlDataReader = command.ExecuteReader
                    While reader.Read
                        list.Add(reader.GetInt32(0))
                    End While
                End Using
            Finally
                If (previousConnectionState = System.Data.ConnectionState.Closed) Then
                    command.Connection.Close()
                End If
            End Try
            Return list
        End Function
    End Class
