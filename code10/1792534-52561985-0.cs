            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("mycontainer");
            await container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var blob = container.GetBlockBlobReference("test.jpg");
            using(var stream = filepond.OpenReadStream()) {
                await blob.UploadFromStreamAsync(stream);
            }
