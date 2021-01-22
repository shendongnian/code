    public class Version
    {
        public int Build { get; set; }
        public int Major { get; set; }
        public int MajorRevision { get; set; }
        public int Minor { get; set; }
        public int MinorRevision { get; set; }
        public int Revision { get; set; }
    }
    // ...
    new XmlSerializer(typeof (Version))
        .Serialize(Console.Out,
                   new Version()
                       {
                           Build = 111,
                           Major = 1,
                           MajorRevision = 0,
                           Minor = 1,
                           MinorRevision = 10,
                           Revision = 10
                       }
        );
