    public class RootObject
    {
        public string type {get;set;}
        public string value {get;set;}
    }
    RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
