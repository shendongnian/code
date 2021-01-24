    public interface IAzureFileStorage {
        CloudStorageAccount StorageAccount { get; }
        CloudBlobClient BlobClient { get; }
        CloudBlobContainer Container { get; }
    }
    public sealed class AzureFileStorage : IAzureFileStorage {
        private readonly AzureBlobSettings _azureBlobSettings;
        
        public AzureFileStorage(IOptions<AzureBlobSettings> fbAuthSettingsAccessor) {
            _azureBlobSettings = fbAuthSettingsAccessor.Value;
            StorageAccount = CloudStorageAccount.Parse(_azureBlobSettings.BlobStorageConnectionString);
            //instantiate the client
            BlobClient = StorageAccount.CreateCloudBlobClient();
            //set the container
            Container = BlobClient.GetContainerReference(_azureBlobSettings.ContainerBlobAzureId);
        }
        
        public CloudStorageAccount StorageAccount { get; private set; }
        public CloudBlobClient BlobClient { get; private set; }
        public CloudBlobContainer Container { get; private set; }
    }
    
