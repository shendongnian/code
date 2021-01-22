    Public Class MyGrid
    Inherits GridView
    Private Sub MyGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Me.RowDataBound
      If Me.AutoGenerateColumns = True Then
        If e.Row.RowType = DataControlRowType.DataRow Then
            For Each c As TableCell In e.Row.Cells
                Dim tb As New TextBox()
                tb.Text = c.Text
                c.Controls.Clear()
                c.Controls.Add(tb)
            Next
        End If
        End If
    End Sub
