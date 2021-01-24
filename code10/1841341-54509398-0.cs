    public interface IStorage
    {
        Task Create(Stream stream, string path);
    }
    public class AzureBlobStorage : IStorage
    {
        public async Task Create(Stream stream, string path)
        {
            // Initialise client in a different place if you like
            string storageConnectionString = "DefaultEndpointsProtocol=https;"
                        + "AccountName=[ACCOUNT]"
                        + ";AccountKey=[KEY]"
                        + ";EndpointSuffix=core.windows.net";
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            var blobClient = account.CreateCloudBlobClient();
            // Make sure container is there
            var blobContainer = blobClient.GetContainerReference("test");
            await blobContainer.CreateIfNotExistsAsync();
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(path);
            await blockBlob.UploadFromStreamAsync(stream);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Put your DI here
            var storage = new AzureBlobStorage();
            // Read a local file
            using (FileStream file = File.Open(@"C:\cartoon.PNG", FileMode.Open))
            {
                try
                {
                    // Pattern to run an async code from a sync method
                    storage.Create(file, "1.png").ContinueWith(t =>
                    {
                        if (t.IsCompletedSuccessfully)
                        {
                            Console.Out.WriteLine("Blob uploaded");
                        }
                    }).Wait();
                }
                catch (Exception e)
                {
                    // Omitted
                }
            }
        }
    }
