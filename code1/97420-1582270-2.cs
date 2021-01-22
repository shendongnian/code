    public static SPList CreateList(string ListName, string description, string templateName, bool Visible,
                                            SPWeb web)
            {
                SPListTemplate template = web.Site.RootWeb.ListTemplates[templateName];
                SPList list = web.Lists[web.Lists.Add(ListName, description, template)];
                list.EnableVersioning = false;
                list.EnableAttachments = false;
                list.OnQuickLaunch = false;
                list.EnableFolderCreation = false;
                list.Update();
                return list;
            }
