    public static class ZipStreamContent
    {
        public static PushStreamContent Create(string fileName, List<MemoryStream> msList)
        {
                var content = new PushStreamContent((outputStream, httpContent, transportContext) =>
                {
                    using (var zip = new ZipArchive(outputStream, ZipArchiveMode.Create, leaveOpen: false))
                    {
                   
                         msList[0].Position = 0;
                        var createenter = zip.CreateEntry("xyz.jpg", CompressionLevel.Optimal);
                        using (var s = createenter.Open())
                        {
                            msList[0].CopyTo(s);
                        }
                                          
                    }
                });
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            content.Headers.ContentDisposition.FileName = fileName;
            return content;
        }
    }
