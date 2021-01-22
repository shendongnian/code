    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim c As Label = e.Row.FindControl("lblColor")
            If c IsNot Nothing Then
                c.BackColor = System.Drawing.Color.FromName(e.Row.DataItem.color_ID)
            End If
        End If
    End Sub
