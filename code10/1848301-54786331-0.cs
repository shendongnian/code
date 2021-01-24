	[XmlRoot(ElementName="CollectionDetails")]
	public class CollectionDetails {
		[XmlElement(ElementName="Collection")]
		public string Collection { get; set; }
		[XmlElement(ElementName="Year")]
		public string Year { get; set; }
		[XmlElement(ElementName="FilePreparationDate")]
		public string FilePreparationDate { get; set; }
	}
	[XmlRoot(ElementName="Source")]
	public class Source {
		[XmlElement(ElementName="ProtectiveMarking")]
		public string ProtectiveMarking { get; set; }
		[XmlElement(ElementName="UKPRN")]
		public string UKPRN { get; set; }
		[XmlElement(ElementName="TransmissionType")]
		public string TransmissionType { get; set; }
		[XmlElement(ElementName="SoftwareSupplier")]
		public string SoftwareSupplier { get; set; }
		[XmlElement(ElementName="SoftwarePackage")]
		public string SoftwarePackage { get; set; }
		[XmlElement(ElementName="Release")]
		public string Release { get; set; }
		[XmlElement(ElementName="SerialNo")]
		public string SerialNo { get; set; }
		[XmlElement(ElementName="DateTime")]
		public string DateTime { get; set; }
	}
	[XmlRoot(ElementName="Header")]
	public class Header {
		[XmlElement(ElementName="CollectionDetails")]
		public CollectionDetails CollectionDetails { get; set; }
		[XmlElement(ElementName="Source")]
		public Source Source { get; set; }
	}
