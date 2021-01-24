    [XmlRoot(ElementName="Policy")]
    public class Policy 
    {
    	[XmlElement(ElementName="PolNumber")]
    	public string PolNumber { get; set; }
    	[XmlElement(ElementName="FirstName")]
    	public string FirstName { get; set; }
    	[XmlElement(ElementName="LastName")]
    	public string LastName { get; set; }
    	[XmlElement(ElementName="BirthDate")]
    	public string BirthDate { get; set; }
    	[XmlElement(ElementName="MailType")]
    	public string MailType { get; set; }
    }
    
    [XmlRoot(ElementName="TxLife")]
    public class TxLife {
    	[XmlElement(ElementName="Policy")]
    	public List<Policy> Policy { get; set; }
    }
