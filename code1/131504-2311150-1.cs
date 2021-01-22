    public class ArtistTopTracks {
        public string name;
        public string mbid;//always empty
        public long reach;
        public string url;
    }
    [XmlRoot("mostknowntracks")]
    public class ApiArtistTopTracks : XmlSerializableBase<ApiArtistTopTracks> {
            [XmlAttribute]
            public string artist;
            [XmlElement("track")]
            public ArtistTopTracks[] track;
    }
