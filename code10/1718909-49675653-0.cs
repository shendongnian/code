        public IActionResult Index(Microsoft.AspNetCore.Http.IFormFile files)
        {
            string storageConnectionString = "connectionstring to your azure file share";
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudFileClient cloudFileClient = cloudStorageAccount.CreateCloudFileClient();
            CloudFileShare cloudFileShare = cloudFileClient.GetShareReference("your file share name");
            cloudFileShare.CreateIfNotExistsAsync();
            CloudFileDirectory rootDirectory = cloudFileShare.GetRootDirectoryReference();
            CloudFile file = rootDirectory.GetFileReference(files.FileName);
            TransferManager.Configurations.ParallelOperations = 64;
            // Setup the transfer context and track the upoload progress
            SingleTransferContext context = new SingleTransferContext();
            
           
            using (Stream s1 = files.OpenReadStream())
            {
                var task = TransferManager.UploadAsync(s1, file);
                task.Wait();
            }
            return RedirectToPage("/Index");
        }
