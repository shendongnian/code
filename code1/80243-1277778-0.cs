		public static bool IsValid(XElement element, params string[] schemas)
		{
			XmlSchemaSet xsd = new XmlSchemaSet();
			XmlReader xr = null;
			foreach (string s in schemas)
			{ // eh, leak 'em. 
				xr = XmlReader.Create(
                    new MemoryStream(Encoding.Default.GetBytes(s)));
				xsd.Add(null, xr);
			}
			XDocument doc = new XDocument(element);
			var errored = false;
			doc.Validate(xsd, (o, e) => errored = true);
			if (errored)
				return false;
			// If this doesn't fail, there's an issue with the XSD.
			XNamespace xn = XNamespace.Get(
                          element.GetDefaultNamespace().NamespaceName);
			XElement fail = new XElement(xn + "omgwtflolj/k");
			fail.SetAttributeValue("xmlns", xn.NamespaceName);
			doc = new XDocument(fail);
			var fired = false;
			doc.Validate(xsd, (o, e) => fired = true);
			return fired;
		}
