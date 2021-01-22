    [XmlRoot("GetAlbums_response")]
    public class GetAlbumsResponse
    {
        public GetAlbumsResponse() 
        {    
        }
      
        [XmlElement("album")]
        public List<Album> Albums { get; set; }
        public static GetAlbumsResponse DeserializeResponseFromXml(string xmlString)
        {
            XmlSerializer ser;
            ser = new XmlSerializer(typeof(GetAlbumsResponse));
            StringReader stringReader;
            stringReader = new StringReader(xmlString);
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(stringReader);
            GetAlbumsResponse response = ser.Deserialize(xmlReader) as GetAlbumsResponse;
            xmlReader.Close();
            stringReader.Close();
            return response;
        }
    }
    
    public class Album
    {
       public Album()
       {}
       [XmlElement("name")]
       public string Name { get; set; }
    }
