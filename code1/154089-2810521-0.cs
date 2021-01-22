    [Serializable]
    [XmlRoot("Car")]
    public class Car1
    {
    	[XmlElement("CarId")]
    	public int Id { get; set; }
    	[XmlElement("CarName")]
    	public string Name { get; set; }
    }
    [Serializable]
    [XmlRoot("Car")]
    public class Car2
    {
    	public int CarId { get; set; }
    	public string CarName { get; set; }
    }
    
    [TestFixture]
    public class CarTest
    {
    	[Test]
    	public void SerializationTest()
    	{
    		var ms = new MemoryStream();
    		var car1 = new Car1 {Id = 10, Name = "Car1"};
    		var xs = new XmlSerializer(typeof(Car1));
    		var tw = new StreamWriter(ms);
    		xs.Serialize(tw, car1);
    
    		ms.Seek(0, SeekOrigin.Begin);
    		xs = new XmlSerializer(typeof(Car2));
    		var tr = new StreamReader(ms);
    		var car2 = (Car2)xs.Deserialize(tr);
    
    		Assert.AreEqual(car1.Id, car2.CarId);
    		Assert.AreEqual(car1.Name, car2.CarName);
    	}
    }
