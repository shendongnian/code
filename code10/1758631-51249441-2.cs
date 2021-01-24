    public class ObjModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    ObjModel[] datas = JsonConvert.DeserializeObject<ObjModel[]>(jsonData);
