	public static class XmlReaderExtensions
	{
		public static bool ReadToFollowingOrCurrent(this XmlReader reader, string localName, string namespaceURI)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));
			if (reader.NodeType == XmlNodeType.Element && reader.LocalName == localName && reader.NamespaceURI == namespaceURI)
				return true;
			return reader.ReadToFollowing(localName, namespaceURI);
		}
	}
