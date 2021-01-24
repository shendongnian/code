    using System;
    using Google.Cloud.Storage.V1;
    
    namespace csharp {
        public class deletingFilesFromBucket
        {
            static void Main(string[] args)
            {
                    var storage = StorageClient.Create();
                    var bucketName = "MyBucket"
                    foreach (var storageObject in storage.ListObjects(bucketName, ""))
                    {
                            storage.DeleteObject(bucketName, storageObject.Name);
                            Console.WriteLine($"Deleted {storageObject.Name}.");
                    }
            }
        } 
    }
