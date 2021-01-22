    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If e.Item.ItemType = ListItemType.Footer Then
            Dim Lit As Literal = CType(e.Item.FindControl("findme"), Literal)
        End If
    End Sub
