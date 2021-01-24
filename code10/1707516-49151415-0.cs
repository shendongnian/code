    private static List<ListItem> GetItemsFromSharePointSiteList(string strListName, string strCamlQuery, ClientContext clientContext)
        {
            try
            {
                ListItemCollectionPosition itemPosition = null;
                List listIPPMilestonesLE = clientContext.Web.Lists.GetByTitle(strListName);
                CamlQuery query = new CamlQuery();
                query.ViewXml = strCamlQuery;
                query.DatesInUtc = false;
                var itemColl = new List<ListItem>();
                do
                {
                    Microsoft.SharePoint.Client.ListItemCollection listItemCollection = listIPPMilestonesLE.GetItems(query);
                    clientContext.Load(listItemCollection);
                    clientContext.ExecuteQuery();
                    //
                    itemColl.AddRange(listItemCollection);
                    
                    itemPosition = listItemCollection.ListItemCollectionPosition;
                } while (itemPosition != null);
                return itemColl;
            }
            catch (Exception exc)
            {
                ErrorLog.Error(exc);
            }
            return null;
        }
