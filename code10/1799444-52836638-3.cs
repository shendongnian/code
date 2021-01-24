    public class ObjectTypes
    {
        [JsonProperty("data")]
        public ObjectTypeList Data { get; set; }
        public ObjectTypes()
        {
            Data = new ObjectTypeList();
        }
    }
    public class ObjectTypeList
    {
        [JsonProperty("objects")]
        public Dictionary<string, ObjectData> Objects { get; set; }
        public ObjectTypeList()
        {
            Objects = new Dictionary<string, ObjectData>();
        }
    }
    public class ObjectData
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
