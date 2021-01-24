    [XmlRoot("package", Namespace = "http://www.idpf.org/2007/opf")]
    public class Package
    {
        [XmlElement("metadata", Namespace = "http://www.idpf.org/2007/opf")]
        public PackageMetadata Metadata { get; set; }
    }
