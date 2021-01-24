    public class BRequest
    {
        public BRequest() { }
        public BRequest(ARequest source)
        {
            this.BText = source.AText;
            this.BProductKey = source.AProductKey;
            this.BSettings = source.ASettings;
        }
        public string BText { get; set; }
        public string BProductKey { get; set; }
        public string BSettings { get; set; }
    }
