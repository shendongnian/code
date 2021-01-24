	[XmlRoot("QCalls")]
	public class QCalls
	{
		[XmlElement("Q")]
		public List<QItem> Items { get; set; }
	}
	public class QItem
	{
		[XmlAttribute("cw")]
		public int CW { get; set; }
	}
	// Deserialization code
	QCalls calls = null;
	var serializer = new XmlSerializer(typeof(QCalls));
    calls = (QCalls)serializer.Deserialize(response.GetResponseStream());
	return calls.Items;
