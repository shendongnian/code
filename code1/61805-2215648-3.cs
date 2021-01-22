    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    {
        using(SPSite site = properties.Feature.Parent as SPSite)
        {
            SPList list = site.RootWeb.Lists["ListName"];
            if(items.ItemCount > 100)
            {        
                SPQuery query = new SPQuery();
                query.RowLimit = 100;
                int index = 1;
                do
                {
                    SPListItemCollection items = list.GetItems(query);
                    foreach (SPListItem listItem in items)
                    {
                        Response.Write(SPEncode.HtmlEncode(listItem["Url"].ToString()) +"<BR>");
                    }
                    query.ListItemCollectionPosition = items.ListItemCollectionPosition;
                    index++;
                } while (query.ListItemCollectionPosition != null);
            }
            else
            {
                SPListItemCollection items = list.Items;
                foreach (SPListItem listItem in items)
                {
                    Response.Write(SPEncode.HtmlEncode(listItem["Url"].ToString()) +"<BR>");
                }
            }
        }
    }
    
