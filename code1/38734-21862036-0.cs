    protected void ListView1_DataBound(object sender, EventArgs e)
    {
        ListView mylist = ((ListView)sender);
        ListViewItem lvi = null;
        if (mylist.Controls.Count == 1)
            lvi = mylist.Controls[0] as ListViewItem;
    
        if (lvi == null || lvi.ItemType != ListViewItemType.EmptyItem)
            return;
    
        Literal literal1 = (Literal)lvi.FindControl("Literal1");
        if (literal1 != null)
            literal1.Text = "No items to display";
    }
