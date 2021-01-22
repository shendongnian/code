    public class File : CustomValidation, IModelBusinessObject
    {
        public int ID { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public int Length { get; set; }
        public string MD5Hash { get; set; }
        public string UploadFileName { get; set; }
    }
