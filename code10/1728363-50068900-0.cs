	public abstract class StreamingXmlSerializableBase : IXmlSerializable
	{
		// Populate the object with the XmlReader returned by ReadSubtree
		protected abstract void Populate(XmlReader reader);
		
        public XmlSchema GetSchema() => null;
        public void ReadXml(XmlReader reader)
        {
			reader.MoveToContent();
			// Consume all child nodes of the current element using ReadSubtree()
			using (var subReader = reader.ReadSubtree())
			{
				subReader.MoveToContent();
				Populate(subReader);
			}
	        reader.Read(); // Consume the end element itself.
        }	
        public abstract void WriteXml(XmlWriter writer);
    }
		
	public abstract class XmlSerializableBase : IXmlSerializable
	{
		// Populate the object with an XElement loaded from the XmlReader for the current node
		protected abstract void Populate(XElement element);
		
        public XmlSchema GetSchema() => null;
        public void ReadXml(XmlReader reader)
        {
			reader.MoveToContent();
			var element = (XElement)XNode.ReadFrom(reader);
			Populate(element);
        }	
		
		public abstract void WriteXml(XmlWriter writer);
	}
