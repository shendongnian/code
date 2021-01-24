    public class WebsiteDetails
    {
        public string TemplateId { get; set; }
        public string WebsiteBusinessName { get; set; }
    }
    
    public class Campaign
    {
        public string CampaignName { get; set; }
    }
    
    public class LineItem
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public WebsiteDetails WebsiteDetails { get; set; }
        public Campaign Campaign { get; set; }
    }
    
    public class Order
    {
        public string Partner { get; set; }
        public string OrderID { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
