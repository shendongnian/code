    [XmlRoot("root")]
    public class Car
    {
    	private static XmlSerializer serializer = new XmlSerializer(typeof(Car));
    
    	[XmlElement("carnumber")]
    	public int Number { get; set; }
    	
    	[XmlElement("carcolor")]
    	public int Color { get; set; }
    	
    	[XmlElement("cartype")]
    	public int Type { get; set; }
    	
    	[XmlIgnore]
    	public CarColor CarColor
    	{
    		get
    		{
    			return (CarColor)Color;
    		}
    		set
    		{
    			Color = (int)value;
    		}
    	}
    	
    	[XmlIgnore]
    	public CarType CarType
    	{
    		get
    		{
    			return (CarType)Type;
    		}
    		set
    		{
    			Type = (int)value;
    		}
    	}
    	
    	public string CarColorString
    	{
    		get
    		{
    			return this.CarColor.ToString().Replace('_', ' ');
    		}
    	}
    	
    	public string CarTypeString
    	{
    		get
    		{
    			return this.CarType.ToString().Replace('_', ' ');
    		}
    	}
    	
    	public string Serialize()
    	{
    		StringBuilder sb = new StringBuilder();
    		using (StringWriter writer = new StringWriter(sb))
    		{
    			serializer.Serialize(writer, this);
    		}
    		return sb.ToString();
    	}
    	
    	public static Car Deserialize(string xml)
    	{
    		using (StringReader reader = new StringReader(xml))
    		{
    			return (Car)serializer.Deserialize(reader);
    		}
    	}
    }
    
    public enum CarColor
    {
    	Red = 1,
    	Blue = 2,
    	Green = 3,
    	Light_Brown = 4
    	// and so on...
    }
    
    public enum CarType
    {
    	Sedan = 1,
    	Coupe = 2,
    	Hatchback = 3,
    	SUV = 4,
    	Pickup_Truck = 5
    	// and so on...
    }
