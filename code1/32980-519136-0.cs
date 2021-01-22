      [XmlRoot (ElementName="GetAlbums_response")]
    public class GetAlbumsResponse
    {
        #region Constructors
        public GetAlbumsResponse()
        {
        }
        #endregion
        
        [XmlArray(ElementName="album")]
        public List<Album> Albums{get;set;}
         
        ... deserialization code...
   }     
