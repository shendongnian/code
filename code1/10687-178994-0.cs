    [Serializable]
    [XmlRoot("Foo")]
    public class Foo
    {
    	[XmlArray("BarList"), XmlArrayItem(typeof(Bar), ElementName = "Bar")]
    	public List<Bar> BarList { get; set; }
    }
