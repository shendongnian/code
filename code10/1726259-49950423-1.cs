    public class CardTemplateDefinition
    {
        [XmlElement("riskInfoList")]      
        public RiskInfoList RiskInfoList { get; set; }
    }
    public class RiskInfoList 
    {
        [XmlElement("riskCount")]
        public string RiskCount { get; set; }
     
        [XmlElement("riskInfo")]
        public List<RiskInfo> RiskInfo { get; set; }
    }
    public class RiskInfo
    {
        [XmlElement("riskType")]
        public string RiskType { get; set; }
        [XmlElement("riskDescription")]
        public string RiskDescription { get; set; }
        [XmlElement("autoRisk")]
        public AutoRiskEntity AutoRisk { get; set; }
        [XmlElement("dwellingRisk")]
        public DwellingRiskEntity DwellingRisk { get; set; }
    }
    public class DwellingRiskEntity
    {
        [XmlElement("location")]        
        public string Location { get; set; }
    }
    public class AutoRiskEntity
    {
        [XmlElement("vin")]
        public string Vin { get; set; }
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("licensePlate")]
        public string LicensePlate { get; set; }
        [XmlElement("year")]
        public string Year { get; set; }
    }
