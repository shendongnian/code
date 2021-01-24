    public class Project
    {
        [JsonProperty("sno")]
        public string Sno { get; set; }
        [JsonProperty("project_name")]
        public string ProjectName { get; set; }
        [JsonProperty("project_Status")]
        public string ProjectStatus { get; set; }
    }
    public class JsonModel
    {
        [JsonProperty("Projects")]
        public List<Project> projects { get; set; }
    }
    JsonConvert.DeserializeObject<JsonModel>(json_Data);
