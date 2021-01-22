    [Serializable]
    [XmlRoot]
    public class CustomBindingList
    {
    	[XmlAttribute]
    	public string publicField;
    	private string privateField;
    
    	[XmlAttribute]
    	public string PublicProperty
    	{
    		get { return privateField; }
    		set { privateField = value; }
    	}
    	
    	[XmlElement]
    	public BindingList<Floor> Floors = new BindingList<Floor>();
    }
