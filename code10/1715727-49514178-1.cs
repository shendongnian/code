    public class Results
    {
        public List<WebResult> Data { get; set; }
    }
    public class WebResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<About> About { get; set; }
    }
    public class About
    {
        public string Name { get; set; }
    }
