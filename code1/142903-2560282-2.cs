    protected void dlCategory_ItemDataBound(object sender, DataListItemEventArgs e) 
    {
        Label Label1 = e.Item.FindControl("Label1") as Label;
        if (LblCat != null)
        {
            string id = ((System.Data.DataRowView)e.Item.DataItem).Row["ProductCategory_Id"].ToString();
            if (Request.QueryString["ProductCategory_Id"] == id)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
