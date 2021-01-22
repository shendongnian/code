    Private Sub ListView1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListView1.ItemDataBound
        If e.Item.ItemType <> ListViewItemType.DataItem Then Exit Sub
        Dim dr = DirectCast(e.Item.DataItem, Data.DataRowView)
        Dim Textbox1 = DirectCast(e.Item.FindControl("Textbox1"), Web.UI.WebControls.TextBox)
        Textbox1.Text = dr("MyColumnName")
    End Sub
