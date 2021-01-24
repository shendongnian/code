    class Config {
        public string uservalue {get;set;}
        public bool ismodified {get;set}
    }
    var c = JsonConvert.DeserializeObject<Dictionary<string, Config>>(jsonString);
    foreach (var x in c) {
        if (x.Value.ismodified) {
        }
    }
