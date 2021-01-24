    #r "Microsoft.WindowsAzure.Storage"
    
    using System;
    using System.Configuration;
    using System.Net;
    using System.Text;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    
    public static async Task Run(string mySbMsg, TraceWriter log)
    {
        log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
    
        string connectionString="{storage acount connectionString}";
        CloudStorageAccount storageAccount;
        CloudBlobClient client;
        CloudBlobContainer container;
        CloudBlockBlob blob;
    
        storageAccount = CloudStorageAccount.Parse(connectionString);
    
        client = storageAccount.CreateCloudBlobClient();
        
        container = client.GetContainerReference("container01");
       
        await container.CreateIfNotExistsAsync();
        
        blob = container.GetBlockBlobReference(DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".json");
        blob.Properties.ContentType = "application/json";
        
        using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(mySbMsg)))
        {
            await blob.UploadFromStreamAsync(stream);
        }
    }
