    [MetadataType(typeof(InvoiceMetadata))]
    public partial class Invoice { 
    
    }
    public partial class InvoiceMetadata {
        [ScaffoldColumn(false)]
        public string InvoiceId { get; set; }
        [ScaffoldColumn(false)]
        public string LiquidatorInvoiceId { get; set; }
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> LastModifiedDate { get; set; }
        [ScaffoldColumn(false)]
        public string LastModifiedBy { get; set; }
        [DisableFilter]
        public LeadAccount LeadAccount { get; set; }
    }
