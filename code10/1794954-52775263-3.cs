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
    // don't make this a DbSet
    public abstract class Version
    {
        [Key]
        public int VersionNumber { get; set; }
        //Other properties
    }
    public class DocumentVersion : Version
    {
        public int DocumentID { get; set; }
        public virtual Document Document { get; set; }
        // other properties
    }
    public class RegisterVersion : Version
    {
        public int RegisterID { get; set; }
        public virtual Register Register { get; set; }}
        // other properties
    }
