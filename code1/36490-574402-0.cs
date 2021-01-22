    Imports System.Data
    Imports System.Data.SqlClient
    Imports System.Data.Sql
    Imports System.Net
    Imports System.IO
    
    Partial Class DownloadFile
    Inherits System.Web.UI.Page
    
    Protected Sub page_load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    Dim url As String = Request.QueryString("DownloadUrl")
    If url Is Nothing Or url.Length = 0 Then Exit Sub
    
    'Initialize the input stream
    Dim req As HttpWebRequest = WebRequest.Create(url)
    Dim resp As HttpWebResponse = req.GetResponse()
    Dim bufferSize As Integer = 1 
    
    'Initialize the output stream
    Response.Clear()
    Response.AppendHeader("Content-Disposition:", "attachment; filename=download.zip")
    Response.AppendHeader("Content-Length", resp.ContentLength.ToString)
    Response.ContentType = "application/download"
    
    'Populate the output stream
    Dim ByteBuffer As Byte() = New Byte(bufferSize) {}
    Dim ms As MemoryStream = New MemoryStream(ByteBuffer, True)
    Dim rs As Stream = req.GetResponse.GetResponseStream()
    Dim bytes() As Byte = New Byte(bufferSize) {}
    While rs.Read(ByteBuffer, 0, ByteBuffer.Length) > 0
    Response.BinaryWrite(ms.ToArray())
    Response.Flush()
    End While
    
    'Cleanup
    Response.End()
    ms.Close()
    ms.Dispose()
    rs.Dispose()
    ByteBuffer = Nothing
    End Sub
    End Class
