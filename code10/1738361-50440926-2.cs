    [XmlRoot(ElementName = "invoices")]
    public class Invoices
    {
        [XmlElement(ElementName = "invoice")]
        public List<Invoice> Invoice { get; set; }
    }
        [XmlRoot("invoice")]
    public class Invoice
    {
        [XmlElement(ElementName = "description", IsNullable = true)]
        public string Description { get; set; }
        [XmlElement(ElementName = "invoice_date")]
        public string InvoiceDate { get; set; }
        [XmlElement(ElementName = "invoice_number")]
        public string InvoiceNumber { get; set; }
        [XmlElement(ElementName = "date_due")]
        public string DateDue { get; set; }
        [XmlElement(ElementName = "amount")]
        public string Amount { get; set; }
    }
