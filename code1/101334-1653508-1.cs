    public class PdfDoc : File
    {
        public int ID { get; set; }
        public int FileID
        {
            get { return base.ID; }
            set { base.ID = value; }
        }
        [StringLength(200, ErrorMessage = "The Link Text must not be longer than 200 characters")]
        public string LinkText { get; set; }
        public PdfDoc() { }
        public PdfDoc(File file)
        {
            MimeType = file.MimeType;
            Data = file.Data;
            Length = file.Length;
            MD5Hash = file.MD5Hash;
            UploadFileName = file.UploadFileName;
        }
        public PdfDoc(File file, string linkText)
        {
            MimeType = file.MimeType;
            Data = file.Data;
            Length = file.Length;
            MD5Hash = file.MD5Hash;
            UploadFileName = file.UploadFileName;
            LinkText = linkText;
        }
    }
