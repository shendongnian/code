    Dim Headers As String = GetHeadersFromRawRequest(ResponseBinary)
       If Headers.IndexOf("Content-Encoding: gzip") > 0 Then
    
         Dim GzSream As New GZipStream(New MemoryStream(ResponseBinary, Headers.Length + (vbNewLine & vbNewLine).Length, ReadByteSize - Headers.Length), CompressionMode.Decompress)
    ClearTextHtml = New StreamReader(GzSream).ReadToEnd()
    End If                         
    
     Private Function GetHeadersFromRawRequest(ByVal request() As Byte) As String
    
            Dim Req As String = Text.Encoding.ASCII.GetString(request)
            Dim ContentPos As Integer = Req.IndexOf(vbNewLine & vbNewLine)
    
            If ContentPos = -1 Then Return String.Empty
    
            Return Req.Substring(0, ContentPos)
        End Function
