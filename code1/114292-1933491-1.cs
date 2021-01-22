    [DataContract(Namespace="....")]
    [XmlType]
    public class ProductCategoryDTO
    {
            [DataMember(Order=1)]
            [XmlElementAttribute(Order=1)]
            public string Name { get; set; }
            [DataMember(Order=2)]
            [XmlElementAttribute(Order=2)]
            public DateTime ModifiedDate { get; set; }
    }
