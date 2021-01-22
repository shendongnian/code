    public partial class Person
    {
        public int PersonId { get; set; }
    }
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
        public partial class PersonMetadata
        {
            [Key]
            public int PersonId { get; set; }
        }
    }
