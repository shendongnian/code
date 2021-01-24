    public class Document
    {
        public virtual List<DocumentVersion>  Versions { get; set; }
        // other properties
    }
    public class Register
    {
        public virtual List<RegisterVersion> Versions { get; set; }
        // other properties
    }
    public class Version
    {
        [Key]
        public int VersionNumber { get; set; }
        //Other properties
    }
    public class DocumentVersion
    {
        public int DocumentID { get; set; }
        public virtual Document Document { get; set; }
        public int VersionID { get; set; }
        public virtual Version Version { get; set; }
        // other properties
    }
    public class RegisterVersion
    {
        public int RegisterID { get; set; }
        public virtual Register Register { get; set; }
        public int VersionID { get; set; }
        public virtual Version Version { get; set; }
        // other properties
    }
