    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool subscribed { get; set; }
    }
    
    public class Thumbnail
    {
        public object small { get; set; }
        public object medium { get; set; }
        public object large { get; set; }
        public object original { get; set; }
    }
    
    public class Banner
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string original { get; set; }
    }
    
    public class Result
    {
        public List<Tag> tags { get; set; }
        public List<string> custom_tags { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string blurb { get; set; }
        public string url { get; set; }
        public DateTime published_at { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Banner banner { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> result { get; set; }
        public DateTime first { get; set; }
        public DateTime last { get; set; }
    }
    var json = webClient.DownloadString(@"https:....");
     var data = JsonConvert.DeserializeObject<RootObject>(json);
     Console.WriteLine(data.result[0].title);
