    rptList.ItemDataBound += rptList_ItemDataBound;
    private void rptList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {   
    	if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
    
    	HtmlControls.HtmlGenericControl RepeaterBG = (HtmlControls.HtmlGenericControl)e.Item.FindControl("RepeaterBG");
    
    	Data.DataRowView dr = (Data.DataRowView)e.Item.DataItem;
    
        RepeaterBG.Style.Add("background-color", dr("ContentBackground"))
    }
