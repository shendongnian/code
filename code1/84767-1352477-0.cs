    [XmlInclude(typeof(MusicAlbum))] // etc other types...
    public abstract class PayloadBase {}
    public class MusicAlbum : PayloadBase
    {
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
    }
    public class ObjectCarrier
    {
        public PayloadBase PayloadObject { get; set; }
    }
