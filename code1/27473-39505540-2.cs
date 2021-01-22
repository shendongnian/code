         Using conn As New System.Data.SQLite.SQLiteConnection(txtConnSqlite.Text)
                Dim FirstIndex As Int32 = txtConnSqlite.Text.IndexOf("Data Source=")
                If FirstIndex = -1 Then MsgBox("ConnectionString is incorrect", MsgBoxStyle.Exclamation, "Sqlite") : Exit Sub
                Dim SecondIndex As Int32 = txtConnSqlite.Text.IndexOf("Version=")
                If SecondIndex = -1 Then MsgBox("ConnectionString is incorrect", MsgBoxStyle.Exclamation, "Sqlite") : Exit Sub
                Dim FilePath As String = txtConnSqlite.Text.Substring(FirstIndex + 12, SecondIndex - FirstIndex - 13)
                If Not IO.File.Exists(FilePath) Then MsgBox("Database file not found", MsgBoxStyle.Exclamation, "Sqlite") : Exit Sub
                Try
                    conn.Open()
                    Dim cmd As New System.Data.SQLite.SQLiteCommand("SELECT * FROM sqlite_master WHERE type='table';", conn)
                    Dim reader As System.Data.SQLite.SQLiteDataReader
                    cmd.ExecuteReader()
                    MsgBox("Success", MsgBoxStyle.Information, "Sqlite")
                Catch ex As Exception
                    MsgBox("Connection fail", MsgBoxStyle.Exclamation, "Sqlite")
                End Try
              End Using
