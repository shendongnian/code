            static void Main(string[] args)
            {
                DataTable dt = new DataTable("table1");
                dt.Columns.Add("name",typeof(string));
                dt.Columns.Add("city",typeof(string));
                dt.Columns.Add("gender",typeof(string));
    
                dt.Rows.Add("jack", "bj", "male");
                dt.Rows.Add("jacky", "sh", "male");
                dt.Rows.Add("iva", "bj", "female");
                dt.Rows.Add("nancy", "wx", "female");
                dt.Rows.Add("ali", "sz", "male");
                dt.Rows.Add("andy", "sz", "male");
    
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
                {
                    WriteExcelFile(document, dt);
                }
    
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("account name", "account key"), true);
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                var cloudBlobContainer = cloudBlobClient.GetContainerReference("test-1");
    
                var blockBlob = cloudBlobContainer.GetBlockBlobReference("data115.xlsx");
                stream.Position = 0;
                blockBlob.UploadFromStream(stream);
    
                Console.WriteLine("completed.");
                Console.ReadLine();
            }
