    [XmlRoot(ElementName = "root")]
    public class Root
    {
    	[XmlElement(ElementName = "MIRs")]
    	public List<MIR> MIRs { get; set; }
    }
