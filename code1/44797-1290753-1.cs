    Option Explicit On
    Option Strict On
    
    Imports System.Net
    
    <HandleError()> _
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
    
        Function Index(ByVal s As String) As ActionResult
            Server.ScriptTimeout = 60 * 60
            If Request.QueryString.ToString <> "" Then s = s + "?" + Request.QueryString.ToString
            Dim req As HttpWebRequest = CType(WebRequest.Create("http://stackoverflow.com/" + s), HttpWebRequest)
            req.AllowAutoRedirect = False
            req.Method = Request.HttpMethod
            req.Accept = Request.Headers("Accept")
            req.Referer = Request.Headers("Referer")
            req.UserAgent = Request.UserAgent
            For Each h In Request.Headers.AllKeys
                If Not (New String() {"Connection", "Accept", "Host", "User-Agent", "Referer"}).Contains(h) Then
                    req.Headers.Add(h, Request.Headers(h))
                End If
            Next
            If Request.HttpMethod <> "GET" Then
                Using st = req.GetRequestStream
                    StreamCopy(Request.InputStream, st)
                End Using
            End If
            Dim resp As WebResponse = Nothing
            Try
                Try
                    resp = req.GetResponse()
                Catch ex As WebException
                    resp = ex.Response
                End Try
    
                If resp IsNot Nothing Then
                    Response.StatusCode = CType(resp, HttpWebResponse).StatusCode
                    For Each h In resp.Headers.AllKeys
                        If Not (New String() {"Content-Type"}).Contains(h) Then
                            Response.AddHeader(h, resp.Headers(h))
                        End If
                    Next
                    Response.ContentType = resp.ContentType
    
                    Using st = resp.GetResponseStream
                        StreamCopy(st, Response.OutputStream)
                    End Using
                End If
            Finally
                If resp IsNot Nothing Then resp.Close()
            End Try
            Return Nothing
        End Function
        Sub StreamCopy(ByVal input As IO.Stream, ByVal output As IO.Stream)
            Dim buf(0 To 16383) As Byte
            Using br = New IO.BinaryReader(input)
                Using bw = New IO.BinaryWriter(output)
                    Do
                        Dim rb = br.Read(buf, 0, buf.Length)
                        If rb = 0 Then Exit Do
                        bw.Write(buf, 0, rb)
                    Loop
                End Using
            End Using
        End Sub
    End Class
