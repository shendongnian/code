    public class Course
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Headline { get; set; }
        public string CreatedBy { get; set; }
        public string ExternalImage { get; set; }
        public string Duration { get; set; }
        public Description Description { get; set; }
    }
    public class Description
    {
        [JsonProperty("What You'll Learn")]
        public List<string> WhatYoullLearn { get; set; }
        public List<string> Requirements { get; set; }
        [JsonProperty("Description")]
        public string DescriptionHtml { get; set; }
    }
