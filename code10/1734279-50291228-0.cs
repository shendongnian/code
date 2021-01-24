    void Main()
    {
    	XmlSerializer serializer = new XmlSerializer(typeof(Session));
    	var sess = serializer.Deserialize(File.OpenRead(@"d:\temp\myxml.xml"));
    	sess.Dump();
    }
    
    [XmlRoot(ElementName = "test")]
    public class Test
    {
    	[XmlAttribute(AttributeName = "arcDetect")]
    	public string ArcDetect { get; set; }
    	[XmlAttribute(AttributeName = "lowerLimitMilliamps")]
    	public string LowerLimitMilliamps { get; set; }
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName = "numTests")]
    	public string NumTests { get; set; }
    	[XmlAttribute(AttributeName = "startConditions")]
    	public string StartConditions { get; set; }
    	[XmlAttribute(AttributeName = "targetOutputKilovolts")]
    	public string TargetOutputKilovolts { get; set; }
    	[XmlAttribute(AttributeName = "testVoltageOutput")]
    	public string TestVoltageOutput { get; set; }
    	[XmlAttribute(AttributeName = "timeHoldSeconds")]
    	public string TimeHoldSeconds { get; set; }
    	[XmlAttribute(AttributeName = "timeRampDownSeconds")]
    	public string TimeRampDownSeconds { get; set; }
    	[XmlAttribute(AttributeName = "timeRampUpSeconds")]
    	public string TimeRampUpSeconds { get; set; }
    	[XmlAttribute(AttributeName = "type")]
    	public string Type { get; set; }
    	[XmlAttribute(AttributeName = "upperLimitMilliamps")]
    	public string UpperLimitMilliamps { get; set; }
    	[XmlAttribute(AttributeName = "powerFactorLowerLimit")]
    	public string PowerFactorLowerLimit { get; set; }
    	[XmlAttribute(AttributeName = "powerFactorUpperLimit")]
    	public string PowerFactorUpperLimit { get; set; }
    	[XmlAttribute(AttributeName = "powerLowerLimitKVA")]
    	public string PowerLowerLimitKVA { get; set; }
    	[XmlAttribute(AttributeName = "powerUpperLimitKVA")]
    	public string PowerUpperLimitKVA { get; set; }
    	[XmlAttribute(AttributeName = "reversePolarity")]
    	public string ReversePolarity { get; set; }
    }
    
    [XmlRoot(ElementName = "test_result")]
    public class Test_result
    {
    	[XmlAttribute(AttributeName = "appliedOutputKilovolts")]
    	public string AppliedOutputKilovolts { get; set; }
    	[XmlAttribute(AttributeName = "leakageMilliamps")]
    	public string LeakageMilliamps { get; set; }
    	[XmlAttribute(AttributeName = "testDurationSeconds")]
    	public string TestDurationSeconds { get; set; }
    	[XmlAttribute(AttributeName = "testState")]
    	public string TestState { get; set; }
    	[XmlAttribute(AttributeName = "timeOfTest")]
    	public string TimeOfTest { get; set; }
    	[XmlAttribute(AttributeName = "powerAV")]
    	public string PowerAV { get; set; }
    	[XmlAttribute(AttributeName = "powerFactor")]
    	public string PowerFactor { get; set; }
    }
    
    [XmlRoot(ElementName = "test_set")]
    public class Test_set
    {
    	[XmlElement(ElementName = "test")]
    	public Test Test { get; set; }
    	[XmlElement(ElementName = "test_result")]
    	public Test_result Test_result { get; set; }
    	[XmlAttribute(AttributeName = "testState")]
    	public string TestState { get; set; }
    }
    
    [XmlRoot(ElementName = "appliance")]
    public class Appliance
    {
    	[XmlElement(ElementName = "test_set")]
    	public List<Test_set> Test_set { get; set; }
    	[XmlAttribute(AttributeName = "overallResult")]
    	public string OverallResult { get; set; }
    	[XmlAttribute(AttributeName = "partNumber")]
    	public string PartNumber { get; set; }
    	[XmlAttribute(AttributeName = "serialNumber")]
    	public string SerialNumber { get; set; }
    }
    
    [XmlRoot(ElementName = "session")]
    public class Session
    {
    	[XmlElement(ElementName = "appliance")]
    	public Appliance Appliance { get; set; }
    	[XmlAttribute(AttributeName = "beginTime")]
    	public string BeginTime { get; set; }
    	[XmlAttribute(AttributeName = "halSerialNumber")]
    	public string HalSerialNumber { get; set; }
    	[XmlAttribute(AttributeName = "testMode")]
    	public string TestMode { get; set; }
    	[XmlAttribute(AttributeName = "userName")]
    	public string UserName { get; set; }
    }
