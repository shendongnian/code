    public class Translation : TableEntity
    {
        public string TranslateFrom { get; set; }
        public string TranslateTo { get; set; }
        public string TranslationId { get; set; }
        public string FieldType { get; set; }
        public string SourceParty { get; set; }
        public string DestinationParty { get; set; }
    }
