    Private Sub MyGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Me.RowDataBound
      If Me.AutoGenerateColumns = True Then
        If e.Row.RowType = DataControlRowType.DataRow Then
              txt As TextBox = new TextBox()
              txt.ID = "myTextBox"
              e.row.cells.add(txt)
        End If
        End If
    End Sub
