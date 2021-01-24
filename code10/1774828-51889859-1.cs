	[XmlRoot( ElementName = "rootnode" )]
	public class RootNode
	{
		[XmlText(typeof(string))]
		[XmlElement( ElementName = "node1", Type = typeof(Node1Type) )]
		[XmlElement( ElementName = "node2", Type = typeof(Node2Type) )]
		public object [] nodes;
	}
