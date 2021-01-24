    public class MemoryPostedFile : HttpPostedFileBase
    {
        private readonly byte[] fileBytes;
        public MemoryPostedFile(byte[] fileBytes, string fileName = null,string ContentType=null)
        {
            this.fileBytes = fileBytes;
            this.FileName = fileName;
            this.ContentType = ContentType;
            this.InputStream = new MemoryStream(fileBytes);
        }
        public override int ContentLength => fileBytes.Length;
        public override string FileName { get; }
        public override string ContentType { get; }
        public override Stream InputStream { get; }
    }
