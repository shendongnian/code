    public class XHtmlOneDTDElementAttibute : ElementRegion {
        public bool IsTag(string tag) {
            return Name.Equals(tag, StringComparison.OrdinalIgnoreCase);
        }
        // The Name should be case-insensitive
        public string Name { get; set; }
        // The Value should be case-sensitive
        public string Value { get; set; }
    }
