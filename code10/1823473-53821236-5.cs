    [XmlRoot(Namespace = "blabla.xsd", ElementName = "transmission", IsNullable = true)]
	public class Transmission
	{
		[XmlElement("DiagnosisErrorResponse")]
		public DiagnosisErrorResponse DiagnosisErrorResponse { get; set; }
	}
	[XmlRoot(Namespace = "blabla.xsd", IsNullable = true)]
	public class DiagnosisErrorResponse
	{
		[XmlElement("ID")]
		public long ID { get; set; }
		[XmlElement("ErrorCode")]
		public int ErrorCode { get; set; }
		[XmlElement("ErrorDescription")]
		public string ErrorDescription { get; set; }
		[XmlElement("ErrorDate")]
		public string ErrorDate { get; set; }
	}
