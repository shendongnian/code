    public partial class Business_attrib2object
    {
        public System.Guid IdClass { get; set; }
        public System.Guid IdAttribute { get; set; }
    
        public Nullable<System.Guid> IdAuthor { get; set; }
    
        public virtual Attributes Attributes { get; set; }
        public virtual Classes Classes { get; set; }
    }
