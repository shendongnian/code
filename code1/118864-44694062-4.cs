    Public Function IsOnlineTest3() As Boolean
        Dim req As System.Net.WebRequest = System.Net.WebRequest.Create("https://www.google.com")
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try
    End Function
