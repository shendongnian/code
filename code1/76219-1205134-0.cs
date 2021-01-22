    Dim rootNode As XmlNode = Nothing
    
    Using ws As New WebsProxy.Webs
        ws.PreAuthenticate = True
        ws.UseDefaultCredentials = True
        ws.Url = <site collection address> + "/_vti_bin/webs.asmx"
        rootNode = ws.GetWebCollection()
    End Using
