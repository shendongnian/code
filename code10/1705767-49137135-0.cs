            MemoryStream archiveStream = new MemoryStream();
            using (ZipArchive archiveFile = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
            {
                foreach (var item in assetsNotDuplicated)
                {
                    // create file streams
                    // add the stream to zip file
                    var entry = archiveFile.CreateEntry(item.Name);
                    using (StreamWriter sw = new StreamWriter(entry.Open()))
                    {
                        sw.Write(item.Url);
                    }
                }
            }
            HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
            responseMsg.Content = new ByteArrayContent(archiveStream.ToArray());
            //archiveStream.Dispose();
            responseMsg.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "allfiles.zip" };
                responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                return responseMsg;
        }
