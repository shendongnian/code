    public class Car
    {
      public string StockNumber { get; set; }
      public string Make { get; set; }
      public string Model { get; set; }
    }
    [XmlRootAttribute("Cars")]
    public class CarCollection
    {
      [XmlElement("Car")]
      public Car[] Cars { get; set; }
    }
...
    using (TextReader reader = new StreamReader(path))
    {
      XmlSerializer serializer = new XmlSerializer(typeof(CarCollection));
      return (CarCollection) serializer.Deserialize(reader);
    }
