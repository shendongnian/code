    //Creating a file and then append
    adlsFileSystemClient.FileSystem.Create(_adlsAccountName, "/raw/Hello.txt",overwrite:true); 
     using (var zipBlobFileStream = new MemoryStream())
        {
            await blockBlob.DownloadToStreamAsync(zipBlobFileStream);
            await zipBlobFileStream.FlushAsync(); 
            zipBlobFileStream.Position = 0;
    
            //use ZipArchive from System.IO.Compression to extract all the files from zip file
            using (var zip = new ZipArchive(zipBlobFileStream))
            {
            //Each entry here represents an individual file or a folder
            foreach (var entry in zip.Entries)
            {
                string destfilename = $"{destcontanierPath2}/"+entry.FullName;
                log.Info($"DestFilename: {destfilename}");
                //creating an empty file (blobkBlob) for the actual file with the same name of file
                var blob = extractcontainer.GetBlockBlobReference($"{destfilename}");
                using (var stream = entry.Open())
                {
                    //check for file or folder and update the above blob reference with actual content from stream
                    if (entry.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                                {
                                    stream.CopyTo(ms);
                                    ms.Position = 0;
                                    blob.UploadFromStream(ms);
                                    ms.Position = 0;                                   
                          adlsFileSystemClient.FileSystem.Append(adlsAccountName, "/raw/Hello.txt", ms);
                                }
                      }
                    }
                }                           
            }
            }
        }
