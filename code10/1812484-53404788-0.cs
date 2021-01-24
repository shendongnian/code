    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.IO;
    
    namespace ConsoleApp17
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connstr = "your connection string";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstr);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("t11");
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("students.csv");
                string text="";
                string temp = "";
                using (var memoryStream = new MemoryStream())
                {
                    blockBlob.DownloadToStream(memoryStream);
                    
                    //remember set the position to 0
                    memoryStream.Position = 0;
                    using (var reader = new StreamReader(memoryStream))
                    {
                        //read the csv file as per line.
                        while (!reader.EndOfStream && !string.IsNullOrEmpty(temp=reader.ReadLine()))
                        {
                            text = text + "***" + temp;
                        }
    
                    }
    
                    
                }
    
                Console.WriteLine(text);
                Console.WriteLine("-------");
                Console.ReadLine();
            }
        }
    }
