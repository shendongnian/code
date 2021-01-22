    public class DocumentLink : Link
    {
    }
    
    public class ImageLink : Link
    {
    }
    
    public class Link
    {
        [XmlText]
        public string Href { get; set; }
    }
    
    public class Values
    {
        [XmlArrayItem(ElementName = "ImageLink", Type = typeof(ImageLink))]
        [XmlArrayItem(ElementName = "DocumentLink", Type = typeof(DocumentLink))]
        public Link[] Links { get; set; }
    }
