    [Serializable]
    public class Shopping
    {
        [XmlArray]
        [XmlArrayItem("Discount")]
        public List<Discount> Discounts { get; set; }
    }
    [Serializable]
    [XmlInclude(typeof(Voucher))]
    [XmlInclude(typeof(Quantity))]
    [XmlRoot("Discount")]
    public class Discount
    {
        public int Amount { get; set; }
    }
    public class Quantity : Discount
    {
        public int MyQuantity { get; set; }
    }
    public class Voucher : Discount
    {
        public string MyVoucherName { get; set; }
    }
