    public class Link
    {
        public long Id { get; set; }
        public long? OtherLinkId { get; set; } // <- Without this you'll be unable to insert a single link.
       
        [ForeignKey("OtherLinkId")] // <- remove this if you use Fluent Configuration.
        public Link OtherLink { get; set; }
    }
