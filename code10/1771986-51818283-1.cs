    [System.Xml.Serialization.XmlElementAttribute("AuctionIdentification", typeof(AuctionIdentification))]
    [System.Xml.Serialization.XmlElementAttribute("deliveryDay", typeof(System.DateTime), DataType="date")]
    [System.Xml.Serialization.XmlElementAttribute("deliveryDays", typeof(DateRange))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
