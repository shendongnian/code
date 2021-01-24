    [XmlRoot("SongList")]
    public class SongList
    {
        [XmlElement("Song")]
        public List<Song> Songs { get; set; }
    }
    public class Song
    {
        [XmlElement("DisplayTitle")]
        public string DisplayTitle { get; set; }
        [XmlElement("IsDirty")]
        public bool IsDirty { get; set; }
        [XmlElement("SwapLanguage")]
        public bool SwapLanguage { get; set; }
        [XmlElement("SongLanguage")]
        public string SongLanguage { get; set; }
        [XmlElement("MediaType")]
        public string MediaType { get; set; }
        [XmlElement("Number")]
        public int Number { get; set; }
        [XmlElement("SongBookName")]
        public string SongBookName { get; set; }
        [XmlElement("ThemeName")]
        public string ThemeName { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
    }
