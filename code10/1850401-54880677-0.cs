    public class NotifyInput
    {
        [ModelBinder(Name = "body-plain")]
        public string BodyPlain { get; set; }
        [ModelBinder(Name = "body-html")]
        public string BodyHtml { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
    public class Attachment
    {
        public int Size { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        [ModelBinder(Name = "content-type")]
        public string ContentType { get; set; }
    }
