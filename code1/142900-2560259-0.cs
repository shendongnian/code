protected void dlCategory_ItemDataBound(object sender, DataListItemEventArgs e) 
{
    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
        Label Lb = (Label)e.Item.FindControl("LblCat"); Lb.ForeColor = System.Drawing.Color.Red;
    }
}
