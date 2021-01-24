    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Threading.Tasks;
    
    namespace AzureBlobConsole
    {
        class Program
        {
            static void Main(string[] args)
            {         
                string conn = "xxxx";
                bool x = CheckExistsAsync(conn, "f11", "222 json test.json").GetAwaiter().GetResult();
    
                //to see if the file exists or not
                Console.WriteLine(x);
                Console.WriteLine("completed.");
                Console.ReadLine();
            }
    
            public static async Task<bool> CheckExistsAsync(string connectionString, string containerName, string fileName)
            {
                var blockBlob = GetBlockBlobReference(connectionString, containerName, fileName);
                return await blockBlob.ExistsAsync();
            }
    
            private static CloudBlockBlob GetBlockBlobReference(string connectionString, string containerName, string fileName)
            {
                return CloudStorageAccount
                    .Parse(connectionString)
                    .CreateCloudBlobClient()
                    .GetContainerReference(containerName)
                    .GetBlockBlobReference(fileName);
            }
    
        }
    }
