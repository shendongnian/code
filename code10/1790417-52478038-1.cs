    public class Source {
        public string Order { get; set; }
        public string PathPattern { get; set; }
    }
    [JsonConverter(typeof(PlayListConverter))]
    public class Playlist {
        public Dictionary<string, Source> Sources { get; set; }
        public Source MasterSource { get; set; }
        // etc
    }
