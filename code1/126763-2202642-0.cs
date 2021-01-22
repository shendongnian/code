    [XmlType(TypeName = "Report")]
    public class Report
    {
        [XmlElement("ReportID")]
        public int ID { get; set; }
    
        [XmlElement("ParameterTemplate", IsNullable=true)]
        public XElement ParameterTemplate { get; set; }
    }
