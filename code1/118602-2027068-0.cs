    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles 
    
    Me.Load
            Session("test") = "testing"
        End Sub
    
        Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
            Dim str As String = Session("test")
            Response.Write(str)
        End Sub
