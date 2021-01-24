    public class EmailDetails
    {
        public string ToMailId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CCList { get; set; }
        public List<AttachmentDetails> Attachments {get;set;}
    }
