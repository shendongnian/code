    public class Order
    {
        public string SubOrderNo { get; set; }
        public string ItemNo { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string TemplateName { get; set; }
        public string ObjectType { get; set; }
        public string ObjectId { get; set; }
        public string SalesStartDate { get; set; }
        public string InfoText { get; set; }
        public object Attachment { get; set; }
        public object TemplateImage { get; set; }
        public string ApprovedBy { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public object Context { get; set; }
        public object TemplateDescription { get; set; }
        public int ColorStatus { get; set; }
        public List<object> spArticles { get; set; }
    }
    
    public class RootObject
    {
        public List<Order> Orders { get; set; }
        public object JsonOrders { get; set; }
    }
