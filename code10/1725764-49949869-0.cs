	public class ReportParameterValuesXDto 
	{
		[XmlElement(ElementName="value")]
		public string Value { get; set; }
		[XmlElement(ElementName="used")]
		public string Used { get; set; }
	}
	public class ReportParametersXDto 
	{
		[XmlElement(ElementName="dataType")]
		public string DataType { get; set; }
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="index")]
		public string Index { get; set; }
		[XmlElement(ElementName="allowMulti")]
		public string AllowMulti { get; set; }
		[XmlElement(ElementName="selectSql")]
		public string SelectSql { get; set; }
		[XmlElement(ElementName="values")]
		public List<ReportParameterValuesXDto> Values { get; set; }
	}
	public class ReportXDto 
	{
		[XmlElement(ElementName="id")]
		public string Id { get; set; }
		[XmlElement(ElementName="reportTitle")]
		public string ReportTitle { get; set; }
		[XmlElement(ElementName="hasParameters")]
		public string HasParameters { get; set; }
		[XmlElement(ElementName="parameters")]
		public ReportParametersXDto Parameters { get; set; }
		[XmlElement(ElementName="sourceSql")]
		public string SourceSql { get; set; }
		[XmlElement(ElementName="report")]
		public string Report { get; set; }
	}
