    public static class XObjectExtensions
    {
        public static XElement SerializeToXElement<T>(this T obj, XContainer parent = null, XmlSerializer serializer = null, XmlSerializerNamespaces ns = null)
        {
			if (obj == null)
				throw new ArgumentNullException();
			// Initially, write to a fresh XDocument to cleanly avoid the exception described in
			// https://stackoverflow.com/questions/19045921/net-xmlserialize-throws-writestartdocument-cannot-be-called-on-writers-created
			var doc = new XDocument();
            using (var writer = doc.CreateWriter())
			{
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj, ns ?? NoStandardXmlNamespaces());
			}
			// Now move to the incoming parent.
			var element = doc.Root;
			if (element != null)
			{
				element.Remove();
				if (parent != null)
				{
					parent.Add(element);
				}
			}
			return element;
        }
		
        public static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
	}
