    using (SPSite site = new SPSite(SPContext.Current.Site.Url))
    {
        using (SPWeb web = site.OpenWeb(SPContext.Current.Web))
        {  
              SPList roomList = web.Lists.TryGetList(LIST_NAME);
                    if (roomList != null)
                    {
                        SPListItem newItem = roomList.AddItem();
                        PopulateListWithData(data, ref newItem);
                        newItem.Update();
                    }
        }
     }
