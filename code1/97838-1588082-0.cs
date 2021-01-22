    [Serializable]
    [XmlRoot(ElementName="dmFile")]
    public class File
    {
        [XmlAttribute(AttributeName="dmUpFileGuid")]
        public string UploadGuid { get; set; }
        [XmlAttribute(AttributeName = "dmFileDescr")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "dmFileMetaType")]
        public string MetaType { get; set; }
        [XmlAttribute(AttributeName = "dmFileGuid")]
        public string FileGuid { get; set; }
        [XmlAttribute(AttributeName = "dmMimeType")]
        public string MimeType { get; set; }
        [XmlAttribute(AttributeName = "dmFormat")]
        public string Format { get; set; }
    }
