    public class SharpZipLibZipResult : FileResult
    {
        private readonly string _fileDownloadName;
        private readonly string[] _filesToZip;
        private const int ChunkSize = 1024;
        public ZipResult(string fileDownloadName, params string[] filesToZip)
            : base("application/octet-stream")
        {
            _fileDownloadName = fileDownloadName;
            _filesToZip = filesToZip;
        }
        protected override void WriteFile(HttpResponseBase response)
        {
            var cd = new ContentDisposition();
            cd.FileName = _fileDownloadName;
            response.AddHeader("Content-Disposition", cd.ToString());
            using (var zipStream = new ZipOutputStream(response.OutputStream))
            {
                foreach (var file in _filesToZip)
                {
                    var entry = new ZipEntry(Path.GetFileName(file));
                    zipStream.PutNextEntry(entry);
                    using (var reader = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        byte[] buffer = new byte[ChunkSize];
                        int bytesRead;
                        while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            byte[] actual = new byte[bytesRead];
                            Buffer.BlockCopy(buffer, 0, actual, 0, bytesRead);
                            zipStream.Write(actual, 0, actual.Length);
                        }
                    }
                }
            }
        }
    }
