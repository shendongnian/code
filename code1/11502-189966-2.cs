    Imports System.Net
    Imports System.Web.HttpUtility
     
    Public Class XMLHTTP
    'Makes an internet connection to specified URL 
       Public Overridable Sub open(ByVal bstrMethod As String, _
         ByVal bstrUrl As String, Optional ByVal varAsync As _
         Object = False, Optional ByVal bstrUser _
         As Object = "", Optional ByVal bstrPassword As Object = "")
           Try
               strUrl = bstrUrl
               strMethod = bstrMethod
    
               'Checking if proxy configuration 
               'is required...(blnIsProxy value 
               'from config file)
               If blnIsProxy Then
               'Set the proxy object
                   proxyObject = WebProxy.GetDefaultProxy()
    
                   'Finding if proxy exists and if so set 
                   'the proxy configuration parameters...
                   If Not (IsNothing(proxyObject.Address)) Then
                       uriAddress = proxyObject.Address
                       If Not (IsNothing(uriAddress)) Then
                           _ProxyName = uriAddress.Host
                           _ProxyPort = uriAddress.Port
                       End If
                       UpdateProxy()
                   End If
                   urlWebRequest.Proxy = proxyObject
               End If
    
               'Make the webRequest...
               urlWebRequest = System.Net.HttpWebRequest.Create(strUrl)
               urlWebRequest.Method = strMethod
    
               If (strMethod = "POST") Then
                   setRequestHeader("Content-Type", _
                       "application/x-www-form-urlencoded")
               End If
    
               'Add the cookie values of jessionid of weblogic 
               'and PH-Session value of webseal 
               'for retaining the same session
               urlWebRequest.Headers.Add("Cookie", str_g_cookieval)
    
           Catch exp As Exception
               SetErrStatusText("Error opening method level url connection")
           End Try
       End Sub
       'Sends the request with post parameters...
       Public Overridable Sub Send(Optional ByVal objBody As Object = "")
           Try
               Dim rspResult As System.Net.HttpWebResponse
               Dim strmRequestStream As System.IO.Stream
               Dim strmReceiveStream As System.IO.Stream
               Dim encode As System.Text.Encoding
               Dim sr As System.IO.StreamReader
               Dim bytBytes() As Byte
               Dim UrlEncoded As New System.Text.StringBuilder
               Dim reserved() As Char = {ChrW(63), ChrW(61), ChrW(38)}
               urlWebRequest.Expect = Nothing
               If (strMethod = "POST") Then
                   If objBody <> Nothing Then
                       Dim intICounter As Integer = 0
                       Dim intJCounter As Integer = 0
                       While intICounter < objBody.Length
                         intJCounter = _
                           objBody.IndexOfAny(reserved, intICounter)
                         If intJCounter = -1 Then
    UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(objBody.Substring(intICounter, _
                                                        objBody.Length - intICounter)))
                           Exit While
                         End If
    UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(objBody.Substring(intICounter, _
                                                            intJCounter - intICounter)))
                         UrlEncoded.Append(objBody.Substring(intJCounter, 1))
                         intICounter = intJCounter + 1
                       End While
    
                       bytBytes = _
                         System.Text.Encoding.UTF8.GetBytes(UrlEncoded.ToString())
                       urlWebRequest.ContentLength = bytBytes.Length
                       strmRequestStream = urlWebRequest.GetRequestStream
                       strmRequestStream.Write(bytBytes, 0, bytBytes.Length)
                       strmRequestStream.Close()
                    Else
                        urlWebRequest.ContentLength = 0
                   End If
               End If
               rspResult = urlWebRequest.GetResponse()
               strmReceiveStream = rspResult.GetResponseStream()
               encode = System.Text.Encoding.GetEncoding("utf-8")
               sr = New System.IO.StreamReader(strmReceiveStream, encode)
    
               Dim read(256) As Char
               Dim count As Integer = sr.Read(read, 0, 256)
               Do While count > 0
                   Dim str As String = New String(read, 0, count)
                   strResponseText = strResponseText & str
                   count = sr.Read(read, 0, 256)
               Loop
           Catch exp As Exception
               SetErrStatusText("Error while sending parameters")
               WritetoLog(exp.ToString)
           End Try
       End Sub
       'Setting header values...
       Public Overridable Sub setRequestHeader(ByVal bstrHeader _
                             As String, ByVal bstrValue As String)
           Select Case bstrHeader
                Case "Referer"
                    urlWebRequest.Referer = bstrValue
                Case "User-Agent"
                    urlWebRequest.UserAgent = bstrValue
                Case "Content-Type"
                    urlWebRequest.ContentType = bstrValue
                Case Else
                    urlWebRequest.Headers(bstrHeader) = bstrValue
           End Select
       End Sub
    
       Private Function UpdateProxy()
           Try
               If Not (IsNothing(uriAddress)) Then
                   If ((Not IsNothing(_ProxyName)) And _
                     (_ProxyName.Length > 0) And (_ProxyPort > 0)) Then
                       proxyObject = New WebProxy(_ProxyName, _ProxyPort)
                       Dim strByPass() As String = Split(strByPassList, "|")
                       If strByPass.Length > 0 Then
                           proxyObject.BypassList = strByPass
                       End If
                       proxyObject.BypassProxyOnLocal = True
                       If blnNetworkCredentials Then
                           If strDomain <> "" Then
                               proxyObject.Credentials = New _
                                 NetworkCredential(strUserName, _
                                 strPwd, strDomain)
                           Else
                                proxyObject.Credentials = New _
                                  NetworkCredential(strUserName, _
                                  strPwd)
                           End If
                       End If
                   End If
               End If
           Catch exp As Exception
               SetErrStatusText("Error while updating proxy configurations")
               WritetoLog(exp.ToString)
           End Try
       End Function
       'Property for setting the Responsetext
       Public Overridable ReadOnly Property ResponseText() As String
           Get
               ResponseText = strResponseText
           End Get
       End Property
    
       Private urlWebRequest As System.Net.HttpWebRequest
       Private urlWebResponse As System.Net.HttpWebResponse
       Private strResponseText As String
       Private strUrl As String
       Private strMethod As String
       Private proxyObject As WebProxy
       Private intCount As Integer
       Private uriAddress As Uri
       Private _ProxyName As String
       Private _ProxyPort As Integer
    End Class
