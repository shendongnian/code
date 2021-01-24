    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    
    namespace ConsoleApp1File
    {
        class Program
        {
            static void Main(string[] args)
            {
                string accountname = "xxx";
                string accountkey = "xxxxxxx";
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountname, accountkey), true);
    
                // Create a CloudFileClient object for credentialed access to Azure Files.
                CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
    
                // Get a reference to the file share.
                CloudFileShare share = fileClient.GetShareReference("s66");
    
                //if fileshare does not exist, create it.
                share.CreateIfNotExists();
    
                if (share.Exists())
                {
    
                    // Get a reference to the root directory for the share.
                    CloudFileDirectory rootDir = share.GetRootDirectoryReference();
    
                    // Get a reference to the directory.
                    CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("CustomLogs");
                    //if the directory does not exist, create it.
                    sampleDir.CreateIfNotExists();
    
                    if (sampleDir.Exists())
                    {
                        // Get a reference to the file.
                        CloudFile file = sampleDir.GetFileReference("Log1.txt");
    
                        // if the file exists, read the content of the file.
                        if (file.Exists())
                        {
                            // Write the contents of the file to the console window.
                            Console.WriteLine(file.DownloadTextAsync().Result);
                        }
                        //if the file does not exist, create it with size == 500bytes
                        else
                        {
                            file.Create(500);
                        }
                    }
                }
    
                Console.WriteLine("--file share test--");
                Console.ReadLine();
    
            }
        }
    }
