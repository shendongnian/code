	[XmlRoot( ElementName = "rootnode" )]
	public class RootNode
	{
		[XmlText]
		public string [] Text;
	
		[XmlElement( ElementName = "node1" )]
		public Node1Type Node1;
	
		[XmlElement( ElementName = "node2" )]
		public Node2Type Node2;
	}
