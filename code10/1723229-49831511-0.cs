    [Serializable, XmlRoot("SomeElement")]
    public class Foo
    {
    	[XmlAttribute]
    	public int SomeAttribute1 { get; set; }
    
    	[XmlAttribute]
    	public int SomeAttribute2 { get; set; }
    
    	[XmlText]
    	public string Raw { get; set; }
    
    	[XmlIgnore]
    	public List<int> Values => Raw
            .Split(new [] {" ", "\n"}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
