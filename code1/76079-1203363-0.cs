        Protected Sub rptDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptDetails.ItemDataBound    
          If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lblA As Label = CType(e.Item.FindControl("lblA"), Label)
            lblA.Text = "Found it!"
          End If
        End Sub
