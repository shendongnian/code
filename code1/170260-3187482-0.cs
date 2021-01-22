                SPDocumentLibrary fromList = (SPDocumentLibrary)SPContext.Current.Site.RootWeb.Lists.TryGetList(ListNames.DocmentListName);
                SPWeb currentWeb = SPContext.Current.Web;
                SPDocumentLibrary toList = (SPDocumentLibrary)currentWeb.Lists.TryGetList(ListNames.DocmentListName);
                SPFileCollection collection = fromList.RootFolder.Files;
                foreach (SPFile item in collection)
                {
                    toList.RootFolder.Files.Add(item.Url, item.OpenBinary());
                }
