    public class OnlineFields
    {
        public string CCode { get; set; }
        public string MNumber { get; set; }
        public string Product { get; set; }
		
		[JsonConverter(typeof(EmbeddedLiteralConverter<JsonFile>))]
        public JsonFile JsonFile { get; set; }
    }
