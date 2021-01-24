    public partial class JSONWord
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }
    public partial class Metadata
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
    public partial class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("lexicalEntries")]
        public LexicalEntry[] LexicalEntries { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("word")]
        public string Word { get; set; }
    }
    public partial class LexicalEntry
    {
        [JsonProperty("entries")]
        public Entry[] Entries { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("lexicalCategory")]
        public string LexicalCategory { get; set; }
        [JsonProperty("pronunciations")]
        public Pronunciation[] Pronunciations { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public partial class Entry
    {
        [JsonProperty("etymologies")]
        public string[] Etymologies { get; set; }
        [JsonProperty("grammaticalFeatures")]
        public GrammaticalFeature[] GrammaticalFeatures { get; set; }
        [JsonProperty("homographNumber")]
        public string HomographNumber { get; set; }
        [JsonProperty("senses")]
        public Sense[] Senses { get; set; }
    }
    public partial class GrammaticalFeature
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public partial class Sense
    {
        [JsonProperty("definitions")]
        public string[] Definitions { get; set; }
        [JsonProperty("examples")]
        public Example[] Examples { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("subsenses")]
        public Subsense[] Subsenses { get; set; }
        [JsonProperty("crossReferenceMarkers")]
        public string[] CrossReferenceMarkers { get; set; }
        [JsonProperty("crossReferences")]
        public CrossReference[] CrossReferences { get; set; }
        [JsonProperty("domains")]
        public string[] Domains { get; set; }
        [JsonProperty("regions")]
        public string[] Regions { get; set; }
    }
    public partial class CrossReference
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public partial class Example
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public partial class Subsense
    {
        [JsonProperty("definitions")]
        public string[] Definitions { get; set; }
        [JsonProperty("domains")]
        public string[] Domains { get; set; }
        [JsonProperty("examples")]
        public Example[] Examples { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public partial class Pronunciation
    {
        [JsonProperty("audioFile")]
        public string AudioFile { get; set; }
        [JsonProperty("dialects")]
        public string[] Dialects { get; set; }
        [JsonProperty("phoneticNotation")]
        public string PhoneticNotation { get; set; }
        [JsonProperty("phoneticSpelling")]
        public string PhoneticSpelling { get; set; }
    }
