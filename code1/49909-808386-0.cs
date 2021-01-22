    Public Shared Function GetCookiesSetByPage(ByVal strUrl As String, ByVal cookieToProvide As String) As IEnumerable(Of String)
        Dim req As System.Net.HttpWebRequest
        Dim res As System.Net.HttpWebResponse
        Dim sr As System.IO.StreamReader
        '--notice that the instance is created using webrequest 
        '--this is what microsoft recomends 
        req = System.Net.WebRequest.Create(strUrl)
        'set the standard header information 
        req.Accept = "*/*"
        req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705)"
        req.ContentType = "application/x-www-form-urlencoded"
        req.AllowAutoRedirect = False
        req.Headers.Add(HttpRequestHeader.Cookie, cookieToProvide)
        res = req.GetResponse()
        'read in the page 
        sr = New System.IO.StreamReader(res.GetResponseStream())
        Dim strResponse As String = sr.ReadToEnd
        'Get the cooking from teh response
        Dim strCookie As String = res.Headers(System.Net.HttpResponseHeader.SetCookie)
        Dim strRedirectLocation As String = res.Headers(System.Net.HttpResponseHeader.Location)
        Dim result As New List(Of String)
        If Not strCookie = Nothing Then
            result.Add(strCookie)
        End If
        result.Add(strRedirectLocation)
        Return result
    End Function
