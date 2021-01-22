        protected void rptContent_DataBound(object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                var x= e.Item.FindControl("xxx") as Label;
                 ...
            }
        }
