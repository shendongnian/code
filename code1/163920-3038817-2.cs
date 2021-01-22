    [Serializable]
    [XmlInclude(typeof(Voucher))]
    [XmlInclude(typeof(Quantity))]
    [XmlRoot("Discount")]
    public class Discount {    }
    public class Quantity : Discount { }
    public class Voucher : Discount { }
