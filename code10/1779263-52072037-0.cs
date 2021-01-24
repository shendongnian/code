     public static void CheckDate()
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["storageConnectionString"]);
                CloudFileClient fileClient = cloudStorageAccount.CreateCloudFileClient();
                CloudFileShare fileShare =
                fileClient.GetShareReference(ConfigurationManager.AppSettings["shareName"]);
    
                var sourceName = fileShare.GetRootDirectoryReference().GetDirectoryReference((ConfigurationManager.AppSettings["sourceName"]));
                IEnumerable<IListFileItem> fileList = sourceName.ListFilesAndDirectories();
    
                listFile(fileList);
    
                var latestFile = (from file in filedataList
                                  orderby file.Properties.LastModified descending
                                  select file).FirstOrDefault();
    
                Console.WriteLine(" LastModified Datetime - " + latestFile.Properties.LastModified.Value.DateTime);
    
            }
    
            public static void listFile(IEnumerable<IListFileItem> results)
            {
                foreach (var item in results)
                {
                    if (item.GetType() == typeof(CloudFileDirectory))
                    {
                        CloudFileDirectory dir = (CloudFileDirectory)item;
                        dir.FetchAttributes();
                        dirList.Add(dir);
                    }
                    else
                    {
                        CloudFile file = (CloudFile)item;
                        file.FetchAttributes();
                        filedataList.Add(file);
                    }
                }
                if (dirList.Count > 0)
                {
                    var latestDir = (from dir in dirList
                                     orderby dir.Properties.LastModified descending
                                     select dir).FirstOrDefault();
                    dirList.Clear();
                    var result = latestDir.ListFilesAndDirectories();
                    listFile(result);
                }
            }
