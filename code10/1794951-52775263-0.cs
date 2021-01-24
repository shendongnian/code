    public class Version
    {
        [Key]
        public int VersionNumber { get; set; }
        public int? DocumentID { get; set; }
        public virtual Document Document { get; set; }
        public int? RegisterID { get; set; }
        public virtual Register Register { get; set; }
        //Other properties
    }
