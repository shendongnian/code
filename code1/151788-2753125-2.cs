    <%@ Page Language="VB" %>
    <%@ Import Namespace="System.IO" %>
    <script runat="server">
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
            Dim base64 As String = File.ReadAllText("E:\mailbox\P3_hemantd.mbx\byte.eml")
            
            Dim newBytes As Byte() = Convert.FromBase64String(base64)
            Response.ClearContent()
            Response.ClearHeaders()
            Response.ContentType = "image/jpeg"
            Response.BinaryWrite(newBytes)
            Response.End()
        End Sub
    </script>
