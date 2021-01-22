        Dim msgPath As String = message.Path
        Dim msgURI As String = message.URI
        Dim msgID As String = message.ID
        MyCredentialCache = New System.Net.CredentialCache()
        MyCredentialCache.Add(New System.Uri(_inboxPath), "BASIC", New System.Net.NetworkCredential(_username, _password, _domain))
        Dim request As WebRequest = WebRequest.Create(msgURI)
        request.Credentials = MyCredentialCache
        request.ContentType = "text/xml"
        request.Headers.Add("Translate", "f")
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim file As FileStream = New FileStream(msgPath, FileMode.CreateNew)
        Dim stream As Stream = response.GetResponseStream()
        Dim buffer() As Byte = New Byte(4096) {}
        Dim len As Integer = stream.Read(buffer, 0, buffer.Length)
        While (len > 0)
            file.Write(buffer, 0, len)
            len = stream.Read(buffer, 0, buffer.Length)
        End While
        file.Close()
        stream.Close()
