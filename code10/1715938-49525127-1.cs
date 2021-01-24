    string containerNamex = "container002";
    string file = "MyTest"; //a blob file named MyTest.txt
    string fileExtension = "txt";
    string downloadPath = @"D:\MyBlob\";
    CloudBlobClient  _cloudBlobClientx = storageAccount.CreateCloudBlobClient();
    _cloudBlobContainerx = _cloudBlobClientx.GetContainerReference(containerNamex);
    CloudBlockBlob blockBlob = _cloudBlobContainerx.GetBlockBlobReference(file + "." + fileExtension);
    var path = downloadPath + file + "." + fileExtension;
    using (var fileStream = System.IO.File.OpenWrite(path))
         {
              fileStream.Position = 1;
              blockBlob.DownloadToStreamAsync(fileStream);
              Console.WriteLine("success");
          }
            
