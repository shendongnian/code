    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label pris = (Label)e.Item.FindControl("bok_prisLabel");
    
            LabelTotalt.Text = (Convert.ToDouble(LabelTotalt.Text) + Convert.ToDouble(pris.Text)).ToString();
        }
    }
