    public class MezeoAccount 
    {
    	public string PsoID { get; set; }
    	public string Email { get; set; }
    	
    	public static MezeoAccount CreateFromXml(XmlDocument xml)
    	{
    		return new MezeoAccount() 
    		{
    			PsoID = xml.Element("psoID").Attribute("ID").Value,
    			Email = doc.Element("email").Value;
    		};
    	}
    }
    
    //Usage
    var mezeoAccount = MezeoAccount.CreateFromXml(xml);
