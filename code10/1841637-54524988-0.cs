`csharp
public class TradeMark
{
    [XmlElement]
    public string MarkVerbalElementText { get; set; }
    [XmlElement]
    public int MarkCurrentStatusCode { get; set; }
    [XmlElement]
    public string ExpiryDate { get; set; } = ""; 
    [XmlIgnore]
    public string IgnoreMe { get; set; } // This will be ignored
}
`
