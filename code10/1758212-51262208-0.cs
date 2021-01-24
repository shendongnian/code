    using ConsoleAppCore.DAL;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.IO;
    namespace ConsoleAppCore
    {
        class Program
        {
            static void Main(string[] args)
            {
                Run();
                Console.WriteLine("Success");
                Console.ReadLine();
            }
            public static void Run()
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=xxxxx;AccountKey=O7xB6ebGq8e86XQSy2vkvSi/x/exxxxxxxxxxkly1DsQPYY5dF2JrAVHtBozbJo29ZrrGJA==;BlobEndpoint=https://xxxx.blob.core.windows.net/;QueueEndpoint=https://xxxx.queue.core.windows.net/;TableEndpoint=https://xxxx.table.core.windows.net/;FileEndpoint=https://xxxx.file.core.windows.net/;");
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = cloudBlobClient.GetContainerReference("containertest");
                container.CreateIfNotExists();
                DirectoryInfo dir = new DirectoryInfo("E://Test");
            
                foreach (FileInfo file in dir.GetFiles())
                {
                    BlobStorage.UploadContent(container, file.OpenRead(), file.Name);
                
                }
            }
        }
    }
