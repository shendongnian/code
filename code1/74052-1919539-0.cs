    Protected Sub ListView_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewUpdateEventArgs) Handles ListView.ItemUpdating
    
            Dim DropDownListddl As DropDownList = ListView.EditItem.FindControl("DropDownListddl")
    
            Lblwarning.Text = DropDownListddl.SelectedValue
    End Sub
