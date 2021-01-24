    class Document
    {
        public Version DocumentVersion { get; set; }
        public int DocumentVersionId { get; set; } // Or whatever datatype your ID is
        // Other properties
    }
    class Register
    {
        public Version RegisterVersion { get; set; }
        public int RegisterVersionId { get; set; } // Or whatever datatype your ID is
        // Other properties
    }
    class Version
    {
        public int VersionNumber { get; set; }
        // Other properties
    }
