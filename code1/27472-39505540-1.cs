         Using conn As New System.Data.SQLite.SQLiteConnection(txtConnSqlite.Text)
                Try
                    conn.Open()
                    Dim cmd As New System.Data.SQLite.SQLiteCommand("SELECT * FROM sqlite_master WHERE type='table';", conn)
                    Dim reader As System.Data.SQLite.SQLiteDataReader
                    cmd.ExecuteReader()
                    MsgBox("Success!!!", MsgBoxStyle.Information, "Sqlite")
                Catch ex As Exception
                    MsgBox("Connection Fail", MsgBoxStyle.Exclamation, "Sqlite")
                End Try
            End Using 
