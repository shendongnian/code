    public enum FileType
    {
        Word,
        Excel,
        RichText,
        PDF
    }
    
    public class FileData
    {
        public FileType TypeOfFile
        {
            get;
            set;
        }
    
        public byte[] Data
        {
            get;
            set;
        }
    }
