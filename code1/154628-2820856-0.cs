    [XmlRoot("Basket")]
    class Basket : List<Fruit>
    {
    }
    [XmlRoot("Fruit")]
    class Fruit
    {
        [XmlText]
        string Value { get; set; }
    }
