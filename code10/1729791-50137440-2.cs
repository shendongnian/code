    public class TableData
    {
        [JsonProperty(PropertyName = "objectsDetected")]
        public List<ObjectsDetected> ObjectsDetected { get; set; }
    
        [JsonProperty(PropertyName = "file_name_at_upload")]
        public int File_Name_At_Upload { get; set; }
    
        [JsonIgnore]
        public string ClassNames => String.Join(",", ObjectsDetected.Select(o => o.className));
    }
