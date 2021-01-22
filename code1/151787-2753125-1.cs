    <%@ Page Language="VB" %>
    
    <%@ Import Namespace="System.IO" %>
    
    <script runat="server">
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
    
            Dim bytes As Byte() = File.ReadAllBytes(Server.MapPath("Chrysanthemum.jpg"))
            Dim base64 As String = Convert.ToBase64String(bytes)
    
            '' base64 is what you say you have
    
    
            Dim newBytes As Byte() = Convert.FromBase64String(base64)
            Response.ClearContent()
            Response.ClearHeaders()
            Response.ContentType = "image/jpeg"
            Response.BinaryWrite(newBytes)
            Response.End()
    
        End Sub
    
    </script>
