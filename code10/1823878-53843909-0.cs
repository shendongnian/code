        public class Common
        {
            //get the storage account
            public static CloudStorageAccount GetStorageAccount(string storageConnectionString)
            {
                CloudStorageAccount storageAccount = null;
                if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
                {
                    return storageAccount;
                }
                else
                {
                    Console.WriteLine(
                        "A connection string has not been defined in the system environment variables. " +
                        "Add a environment variable named 'storageconnectionstring' with your storage " +
                        "connection string as a value.");
                }
    
                return null;
            }
    
            //get the blob url
            public static async Task<string> GetBlobUrl(CloudStorageAccount storageAccount,string BlobContainerName,string filename)
            {
                try
                {
    
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("tncdata");
                    await cloudBlobContainer.CreateIfNotExistsAsync();
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);
    
                    var blobUrl = "";
                    string file = Guid.NewGuid().ToString() + Path.GetExtension(filename);
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(file);
                    try
                    {
                        await cloudBlockBlob.UploadFromFileAsync(filename);
    
                    }
                    catch (Exception ex)
                    {
    
                    }
                    blobUrl = cloudBlockBlob.Uri.AbsoluteUri;
                    return blobUrl;
                }
                catch (StorageException ex)
                {
                    Console.WriteLine("Error returned from the service: {0}", ex.Message);
                }
                finally
                {
    
                }
    
                return null;
            }
    
            //get or create table async
            public static async Task<CloudTable> GetTableAsnyc(CloudStorageAccount storageAccount,string tablename)
            {
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference("CommonURL");
                await table.CreateIfNotExistsAsync();
    
                return table;
            }
    
            //get or create table
            public static CloudTable GetTable(CloudStorageAccount storageAccount, string tablename)
            {
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference(tablename);
    
                return table;
            }
    
        }
