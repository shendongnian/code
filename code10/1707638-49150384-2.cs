    ...
    [JsonIgnore]
    public RealmDictionary RealmNames { get; set; }
    public Dictionary<string,string> Names {
        get {
            return RealmNames.AsDictionary
        }   
    }
    ...
