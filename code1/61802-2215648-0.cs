    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    {
        using(SPSite site = properties.Feature.Parent as SPSite)
        {
            SPList list = site.RootWeb.Lists["ListName"];
            SPListItemCollection items = list.Items;
            foreach (SPListItem listItem in items)
            {
                Response.Write(SPEncode.HtmlEncode(listItem["Url"].ToString()) +"<BR>");
            }
        }
    }
