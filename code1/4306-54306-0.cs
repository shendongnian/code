    <System.Diagnostics.Conditional("DEBUG")> _
        Private Sub CheckHTTPRequest(ByVal functionName As String)
            Dim e As New UTF8Encoding()
    
            Dim bytes As Long = Me.Context.Request.InputStream.Length
            Dim stream(bytes) As Byte
            Me.Context.Request.InputStream.Seek(0, IO.SeekOrigin.Begin)
            Me.Context.Request.InputStream.Read(stream, 0, CInt(bytes))
    
            Dim thishttpRequest As String = e.GetString(stream)
    
            My.Computer.FileSystem.WriteAllText("D:\SoapRequests\" & functionName & ".xml", thishttpRequest, False)
    
        End Sub
