    public void CopyFiles(string listTitle, string srcRelativeSource, string destRelativeSource)
        {
            var srcList = ClientContext.Web.Lists.GetByTitle(listTitle);
            var qry = CamlQuery.CreateAllItemsQuery();
            qry.FolderServerRelativeUrl = string.Format("/{0}", srcRelativeSource);
            var srcItems = srcList.GetItems(qry);
            ClientContext.Load(srcItems, icol => icol.Include(i => i.FileSystemObjectType, i => i["FileRef"], i => i.File));
            ClientContext.ExecuteQuery();
            createThisFolder(destRelativeSource);
            foreach (var item in srcItems)
            {
                switch (item.FileSystemObjectType)
                {
                    case FileSystemObjectType.Folder:
                        var destFolderUrl = ((string)item["FileRef"]).ToLower().Replace(srcRelativeSource, destRelativeSource);
                        createThisFolder(destFolderUrl);
                        break;
                    case FileSystemObjectType.File:
                        var destFileUrl = item.File.ServerRelativeUrl.ToLower().Replace(srcRelativeSource, destRelativeSource);
                        item.File.CopyTo(destFileUrl, true);
                        ClientContext.ExecuteQuery();
                        break;
                }
            }
        }
        private void createThisFolder(string destFolderUrl)
        {
            //change destFolderUrl into absolute url
            Uri u = new Uri(ClientContext.Web.Context.Url);
            //remove the string after the last slash
            int idx = destFolderUrl.LastIndexOf('/');
            string path = destFolderUrl.Substring(0, idx);
            string lastFolder = destFolderUrl.Split('/').Last();
            string filtered = (path.StartsWith("/")) ? path.Substring(1) : path;
            string url = u.GetLeftPart(UriPartial.Authority) + "/" + filtered;
            CreateFolder(url, lastFolder);
        }      
