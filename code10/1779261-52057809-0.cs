        List<CloudFile> list = new List<CloudFile>();
        public async void TestAsync()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["storageConnectionString"]);
            CloudFileClient fileClient = cloudStorageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = 
            fileClient.GetShareReference(ConfigurationManager.AppSettings["shareName"]);
            var sourceName = fileShare.GetRootDirectoryReference().GetDirectoryReference((ConfigurationManager.AppSettings["sourceName"]));
            IEnumerable<IListFileItem> fileList = sourceName.ListFilesAndDirectories();
            listFile(fileList);
            var test = (from file in list
                          orderby file.Properties.LastModified descending
                          select file).FirstOrDefault();
            
        }
        // detect all files in the directory
        public void listFile(IEnumerable<IListFileItem> results)
        {
            foreach (IListFileItem fileItem in results)
            {
                if (fileItem.GetType() == typeof(CloudFileDirectory))
                {
                    CloudFileDirectory directory = (CloudFileDirectory)fileItem;
                    var res = directory.ListFilesAndDirectories();
                    listFile(res);
                }
                else
                {
                    CloudFile file = (CloudFile)fileItem;
                    file.FetchAttributes();
                    list.Add(file);
                }
            }
        }
