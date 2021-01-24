    <?xml version="1.0" ?>
    <QIMonthReturn xmlns="SomeNamespaceHere">
        <PatientKey>25</PatientKey>
        <Months>
            <QIMonth>
                <Date>2018-05-03T11:13:02.1312881-04:00</Date>
                <Numerator>false</Numerator>
                <Denominator>true</Denominator>
            </QIMonth>
        </Months>
    </QIMonthReturn>
    [XmlRoot("QIMonthReturn", Namespace="SomeNamespaceHere")]
    public class QIMonthReturn
    {
        public QIMonthReturn()
        {
            Months = new List<QIMonth>();
        }
    
        [XmlElement(ElementName = "PatientKey")]
        public string PatientKey { get; set; }
    
        [XmlArray("Months"), XmlArrayItem("QIMonth")]
        public List<QIMonth> Months { get; set; }
    }
    public static T xmlToObject<T>(string strXML)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
    
        StringReader rdr = new StringReader(strXML);
    
        return (T)serializer.Deserialize(rdr);
    }
