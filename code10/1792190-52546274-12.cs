    [XmlRoot(ElementName = "root")]
    public class Root
    {
    	[XmlArray(ElementName = "MIRs")]
    	public List<MIR> MIRs { get; set; }
    }
