        protected void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {
                Site site = e.Item.DataItem as Site; //List<Site> is what you are binding to the repeater
                if (site.SiteId == currentSiteId)
                {
                    var btn = e.Item.FindControl("btnRevert") as Button;
                    if (btn != null)
                    {
                        btn.Visible = false;
                    }
                }
            }
        } 
