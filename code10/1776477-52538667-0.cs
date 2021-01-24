    public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
			var filename = $"{DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss")}.jpg";
			Byte[] screen = ss.AsByteArray;
			
			
            UploadImage_URL(filename, array);
        }
		
		public static void UploadImage_URL(string filename, byte[] array)
        {
            string accountname = "";
            string accesskey = "";
            try
            {
                StorageCredentials creden = new StorageCredentials(accountname, accesskey);
                CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
                CloudBlobClient client = acc.CreateCloudBlobClient();
                CloudBlobContainer cont = client.GetContainerReference("validation-results");
                cont.CreateIfNotExists();
                cont.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
                CloudBlockBlob cblob = cont.GetBlockBlobReference(filename);
                cblob.UploadFromByteArrayAsync(array, 0, array.Lenght);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
