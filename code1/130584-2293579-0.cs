    public static void CreatePage(string url, string pageName, string title, string layoutName, Dictionary<string, string> fieldDataCollection)
        {
            var relUrl = new Uri(url);
            
            using (SPSite site = new SPSite(url))
            using (SPWeb web = site.AllWebs[relUrl.AbsolutePath])
            {
                if (!PublishingWeb.IsPublishingWeb(web))
                    throw new ArgumentException("The specified web is not a publishing web.");
                PublishingWeb pubweb = PublishingWeb.GetPublishingWeb(web);
                PageLayout layout = null;
                string availableLayouts = string.Empty;
                foreach (PageLayout lo in pubweb.GetAvailablePageLayouts())
                {
                    availableLayouts += "\t" + lo.Name + "\r\n";
                    if (lo.Name.ToLowerInvariant() == layoutName.ToLowerInvariant())
                    { layout = lo; break; }
                }
                if (layout == null)
                    throw new ArgumentException("The layout specified could not be found.  Available layouts are:\r\n" + availableLayouts);
                if (!pageName.ToLowerInvariant().EndsWith(".aspx")) pageName += ".aspx";
                PublishingPage page = pubweb.GetPublishingPages().Add(pageName, layout);
                page.Title = title;
                SPListItem item = page.ListItem;
                foreach (string fieldName in fieldDataCollection.Keys)
                {
                    string fieldData = fieldDataCollection[fieldName];
                    try
                    {
                        SPField field = item.Fields.GetFieldByInternalName(fieldName);
                        if (field.ReadOnlyField)
                        {
                            Console.WriteLine("Field '{0}' is read only and will not be updated.", field.InternalName);
                            continue;
                        }
                        if (field.Type == SPFieldType.Computed)
                        {
                            Console.WriteLine("Field '{0}' is a computed column and will not be updated.", field.InternalName);
                            continue;
                        }
                        if (field.Type == SPFieldType.URL)
                        {
                            item[field.Id] = new SPFieldUrlValue(fieldData);
                        }
                        else if (field.Type == SPFieldType.User)
                        {
                           // AddListItem.SetUserField(web, item, field, fieldData);
                        }
                        else
                        {
                            item[field.Id] = fieldData;
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("WARNING: Could not set field {0} for item {1}.", fieldName, item.ID);
                    }
                } 
                page.Update();
            }
        }
