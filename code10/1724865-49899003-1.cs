      protected void dlChild_ItemDataBound(object sender, DataListItemEventArgs e)
            {
               
             if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var lblid = e.Item.FindControl("lblid") as Label;
                    if (lblid != null)
                    {
                        Response.Write(lblid .Text);
                    }
                }
            }
