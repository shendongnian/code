    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    using System.IO;
    
    namespace ConsoleApp19
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s1 = "";
    
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("your account", "your key"), true);
                CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
                CloudFileShare share = fileClient.GetShareReference("t11");
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();
                CloudFile file =rootDir.GetFileReference("test.txt");
    
                if (file.Exists())
                {
                    using (var ms = new MemoryStream())
                    {
                        long? offset = Convert.ToInt64(file.Properties.Length * .8);
                        long? length = Convert.ToInt64(file.Properties.Length * .20);
    
                        file.DownloadRangeToStream(ms, offset, length);
                        //set the position of memory stream to zero
                        ms.Position = 0;
                        using (var sr = new StreamReader(ms))
                        {
                            s1 = sr.ReadToEnd();
                        }
    
                        Console.WriteLine(s1);
                    }
    
                }
    
                Console.WriteLine("---done---");
                Console.ReadLine();
            }
        }
    } 
