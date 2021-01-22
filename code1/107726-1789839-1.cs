    [XmlRoot("order")] public class Order {
        [XmlElement("user")] public int User { get; set; }
        [XmlElement("creditcardtype")] public int CreditCardType { get; set; }
        [XmlElement("country")] public string Country { get; set; }
        [XmlElement("orderDetails")] public OrderDetails Details { get; set; }
    }
    public class OrderDetails {
        [XmlElement("amount")] public int Amount { get; set; }
        [XmlElement("shipping")] public int Shipping { get; set; }
    }
    ....
    var order = new Order {
        User = 2343, CreditCardType = 2333, Country = "USA",
        Details = new OrderDetails {
            Amount = 23434,
            Shipping = 32
        }
    };
    XmlSerializer ser = new XmlSerializer(order.GetType());
    StringWriter sw = new StringWriter();
    ser.Serialize(sw, order);
    string s = sw.ToString();
