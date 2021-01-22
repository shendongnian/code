        Dim rdr As SqlDataReader
        'some code here to populate SqlDataReader with data from the database.
        'could be either a call to another object that handles data layer access,
        'or could setup the SqlDataReader to read directly from the database
        If Not rdr Is Nothing Then
            Try
                If rdr.HasRows Then
                    While rdr.Read()
                        'do stuff
                    End While
                End If
                If Not rdr.IsClosed Then
                    rdr.Close()
                End If
            Catch ex As Exception
                If Not rdr.IsClosed Then
                    rdr.Close()
                End If
            End Try
        End If
