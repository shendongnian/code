    Protected Sub MyGridView_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles MyGridView.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) AndAlso (Not e.Row.DataItem Is Nothing) AndAlso (CInt(e.Row.DataItem("dummyRow")) = 1) Then
              e.Row.Visible = False
        End If
    End Sub
