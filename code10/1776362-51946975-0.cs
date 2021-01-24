    protected void Button1_Click(object sender, EventArgs e)
            {
                CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials("accountname", "accountkey"), true);
                var blobClient = account.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference("container");
                var blob = container.GetBlockBlobReference("text.PNG");
                var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10),//assuming the blob can be downloaded in 10 miinutes
                }, new SharedAccessBlobHeaders()
                {
                    ContentDisposition = "attachment; filename=file-name"
                });
                var blobUrl = string.Format("{0}{1}", blob.Uri, sasToken);
                Response.Redirect(blobUrl);
            }
