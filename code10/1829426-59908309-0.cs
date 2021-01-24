    Public cn As New MySqlConnection()
    Public Sub openconnection()
        If cn.State <> ConnectionState.Open Then
            cn.ConnectionString = "Server=website.com; Database=YourDatabaseName; Uid=YourUsername; Pwd=YourPassword"
            cn.Open()
        End If
    End Sub
    Public Sub closeconnection()
        cn.Close()
    End Sub
