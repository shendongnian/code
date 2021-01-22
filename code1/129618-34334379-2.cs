            using (var outStream = new MemoryStream())
                    {
                        using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                        {
                            var fileInArchive = archive.CreateEntry("FileName.pdf", CompressionLevel.Optimal);
                            using (var entryStream = fileInArchive.Open())
                            using (WebResponse response = req.GetResponse())
                            {
                                using (var fileToCompressStream = response.GetResponseStream())
                                {
                                    fileToCompressStream.CopyTo(entryStream);
                                }
                            }                       
                        }
                        using (var fileStream = new FileStream(@"D:\test.zip", FileMode.Create))
                        {
                            outStream.Seek(0, SeekOrigin.Begin);
                            outStream.CopyTo(fileStream);
                        }
                    }
