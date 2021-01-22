    Imports System.Web.HttpContext
    Public Shared Sub SetSSL(Optional ByVal bEnable As Boolean = False)
      If bEnable Then
        If Not Current.Request.IsSecureConnection Then
    	  Dim strHTTPS As String = "https://www.mysite.com"
          Current.Response.Clear()
          Current.Response.Status = "301 Moved Permanently"
          Current.Response.AddHeader("Location", strHTTPS & Current.Request.RawUrl)
          Current.Response.End()
        End If
      Else
        If Current.Request.IsSecureConnection Then
    	  Dim strHTTP As String = "http://www.mysite.com"
          Current.Response.Clear()
          Current.Response.Status = "301 Moved Permanently"
          Current.Response.AddHeader("Location", strHTTP & Current.Request.RawUrl)
          Current.Response.End()
        End If
      End If
    End Sub
