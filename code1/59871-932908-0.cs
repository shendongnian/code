    public class XHtmlOneDTDElementAttibute : ElementRegion {
        string name;
        // The Name should be case-insensitive
        public string Name {
            get { return name; }
            set { name = value.ToUpperInvariant(); }
        }
        // The Value should be case-sensitive
        public string Value { get; set; }
    }
