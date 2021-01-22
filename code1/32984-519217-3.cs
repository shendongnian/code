    [XmlRoot("photos_getAlbums_response", Namespace="http://api.facebook.com/1.0/")]
    public class GetAlbumsResponse
    {
        public GetAlbumsResponse() 
        {    
        }
      
        [XmlElement("album")]
        public List<Album> Albums { get; set; }
    }
    
    public class Album
    {
        [XmlElement("aid")]
        public long Aid{get;set;}
        [XmlElement("cover_pid")]
        public long CoverPid{get;set;}
        [XmlElement("owner")]
        public long Owner{get;set;}
        [XmlElement("name")]
        public string Name{get;set;}
        [XmlElement("created")]
        public long Created{get;set;}
        [XmlElement("modified")]
        public long Modified{get;set;}
        [XmlElement("description")]
        public string Description{get;set;}
 
        [XmlElement("location")]
        public string Location{get;set;}
        [XmlElement("link")]
        public string Link{get;set;}
        [XmlElement("size")]
        public int Size{get;set;}
   
        [XmlElement("visible")]
        public string Visible{get;set;}
        public Album()
        {}
    }
    class XmlUtils
    {
        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }
    }
