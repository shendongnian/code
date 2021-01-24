    [XmlRoot(ElementName = "Curve")]
    public class ObjectModel {
    	[XmlElement(ElementName = "segments")]
    	public CurveType CurveTypes {get; set;}
    }
