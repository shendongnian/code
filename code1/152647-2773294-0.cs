        Public Event GridPageChanged(ByVal grid As GridView)
    
        Private Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
            RaiseEvent GridPageChanged(Me.GridView1)
        End Sub
