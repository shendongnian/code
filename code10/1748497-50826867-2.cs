    public void DeserializeMyJsonObject()
    {
        string json;
        using (StreamReader r = new StreamReader("d:\\json.txt"))
        {
            json = r.ReadToEnd();
        }
        var myStruct = JsonConvert.DeserializeObject<YourStruct>(json);
    }
    public struct YourStruct
    {
        [JsonProperty("params")]
        public List<Object> KeyAndProperties { get; set; }
    }
