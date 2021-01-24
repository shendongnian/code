    public class Item
    {
    	[XmlAttribute()]
    	public string Price;
    	[XmlAttribute()]
    	public string UnitOfMeasure;
    	[XmlElement()]
    	public TaxDetails TaxAmount;
    }
    
    public class TaxDetails
    {	
    	[XmlAttribute("Included")]
    	public string TaxAmountIncluded;
    	[XmlAttribute()]
    	public string Amount;
    }
