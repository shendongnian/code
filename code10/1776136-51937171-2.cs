    public class FileCollection
    {
        [JsonProperty("files")]
        public List<Dictionary<string, bool>> Files { get; set; }
        public FileCollection()
        {
            Files = new List<Dictionary<string, bool>>();
        }
    }
