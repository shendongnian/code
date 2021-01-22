    Protected Sub Texbox_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Param As String = CType(sender, TextBox).Text
        Dim Result As String = Param 'TODO: perform calculation
        CType(GridView1.Rows(GridView1.EditIndex).FindControl("TextBox2"), TextBox).Text = Result
    End Sub
