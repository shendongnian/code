    public class Item
    {
        public string Srno { get; set; }
        public string InvTypeID { get; set; }
        public string ItemCode { get; set; }
        public string MUnitCode { get; set; }
        public string Specfication { get; set; }
        public string Qty { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string STax { get; set; }
        public string STaxAmount { get; set; }
        public string GrossAmount { get; set; }
    }
    
    public class RootObject
    {
        public string PO_ID { get; set; }
        public string PONo { get; set; }
        public string PODate { get; set; }
        public string RequisitionDate { get; set; }
        public string DeliveryDate { get; set; }
        public string IsCancelled { get; set; }
        public string IsClosed { get; set; }
        public string IsPending { get; set; }
        public object Party_Code { get; set; }
        public string SellerQuotRefNo { get; set; }
        public string SellerQuotDate { get; set; }
        public string ComparativeRefNo { get; set; }
        public string WithItemCode { get; set; }
        public string ValidateQty { get; set; }
        public string TermsOfDelivery { get; set; }
        public string TermsOfPayment { get; set; }
        public string TermsOfConditions { get; set; }
        public List<Item> items { get; set; }
        public string AddNew { get; set; }
    }
