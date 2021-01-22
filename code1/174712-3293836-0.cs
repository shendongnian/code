        Private Sub rptList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptList.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    'ok'
                Case Else
                    Exit Sub
            End Select
    
            Dim RepeaterBG = DirectCast(e.Item.FindControl("RepeaterBG"), UI.HtmlControls.HtmlGenericControl)
        
            Dim dr = DirectCast(e.Item.DataItem, Data.DataRowView)
    
            RepeaterBG.InnerHtml = dr("TitleImgUrl")
        End Sub
