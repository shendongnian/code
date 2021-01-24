       CloudBlockBlob blob = null;
       //azure storage connection
       var container = GetBlobClient(tenantInfo);
       //directory reference
       var directory = container.GetDirectoryReference(
       string.Format(DirectoryNameConfigValue, tenantInfo.TenantId.ToString(), documentList[0].ProjectId));
      var pushStreamContent = new PushStreamContent(async (outputStream, httpContent, transportContext) =>
      {
                //zip the multiple files
                using (var zipEntry = new ZipArchive(outputStream, ZipArchiveMode.Create, leaveOpen: false))
                {
                    for (int docId = 0; docId < documentList.Count; docId++)
                    {
                        blob = directory.GetBlockBlobReference(DocumentNameConfigValue + documentList[docId].DocumentId);
                        if (!blob.Exists()) continue;
                        
                        MemoryStream memStream = new MemoryStream();
                        await blob.DownloadToStreamAsync(memStream);
                        memStream.Position = 0;
                        var createEntry = zipEntry.CreateEntry(documentList[docId].FileName, CompressionLevel.Fastest);
                        using (var stream = createEntry.Open())
                        {
                            memStream.CopyTo(stream);
                        }
                    }
                }
       });  
