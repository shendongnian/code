    public class RootObject
    {
        public Data[] data { get; set; } 
    }
    RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
