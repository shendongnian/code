    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.IO;
    using System.Text;
    
    namespace AzureBlobConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("your_storage_account", "storage_account_key"), true);
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = client.GetContainerReference("f11");
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference("t2.csv");
                
                //download the .csv file into a text
                string s1 = blob.DownloadText();
    
                //split the text into an array
                string[] temp = s1.Split('\r');
                
                // variable s used to store the updated text from .csv
                string s = "";
    
                //because the last element of the array is redundant data("\n"), so we use temp.Length-1 to abandon it.
                for (int i=0;i<temp.Length-1;i++)
                {
                    if (i == 0)
                    {
                        temp[i] += ",ColA,ColB"+"\r\n";
                    }
                    else
                    {
                        temp[i] += ",cc,dd"+"\r\n";
                    }
    
                    s += temp[i];
                }
    
                //upload the updated .csv file into azure
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
                blob.UploadFromStream(stream);         
                
                Console.WriteLine("completed.");
                Console.ReadLine();
            }      
    
        }
    }
