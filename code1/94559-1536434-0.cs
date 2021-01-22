	void Main()
	{
		string xml1 = @"<ROOT>
		<ID>2</ID>
		<PART>4a</PART>
		<NAME>JEFF</NAME>
		<ADDRESS>
			<ST>10001</ST>
			<ID>123456789</ID>
		</ADDRESS>
		<PARTNUMBER>001</PARTNUMBER>
		<DATE>2009 -06-05T16.18.05</DATE>
		</ROOT>";
		
		
		string xml2 = @"<ROOT>
		<ID>2</ID>
		<PART>4b</PART>
		<NAME>JEFF</NAME>
		<RELATIVE>
			<ST>10001</ST>
			<ID>1234567890QWERTYUIOP</ID>
		</RELATIVE>
		<PARTNUMBER>002</PARTNUMBER>
		<DATE>2009 -06-05T16.17.41</DATE>
		</ROOT>";
		
		var doc1 = XDocument.Parse(xml1);
		var doc2 = XDocument.Parse(xml2);
	
		XDocument doc = MergeDocuments(doc1, doc2);
		doc.Dump();
	}
	static XDocument MergeDocuments(XDocument doc1, XDocument doc2)
	{
		var root = MergeElements(doc1.Root, doc2.Root);
		return new XDocument(root);
	}
	static XElement MergeElements(XElement e1, XElement e2)
	{
		var attrComparer = new XAttributeEqualityComparer();
		var nameComparer = new XNameComparer();
		var attributes = e2.Attributes().Union(e1.Attributes(), attrComparer).Cast<XNode>();
		var elements1 = e1.Elements().OrderBy(e => e.Name, nameComparer).ToArray();
		var elements2 = e2.Elements().OrderBy(e => e.Name, nameComparer).ToArray();
		var elements = new List<XNode>();
		int i1 = 0, i2 = 0;
		while (i1 < elements1.Length && i2 < elements2.Length)
		{
			XElement e = null;
			int compResult = nameComparer.Compare(elements1[i1].Name, elements2[i2].Name);
			if (compResult < 0)
			{
				e = elements1[i1];
				i1++;
			}
			else if (compResult > 0)
			{
				e = elements2[i2];
				i2++;
			}
			else
			{
				e = MergeElements(elements1[i1], elements2[i2]);
				i1++;
				i2++;
			}
			elements.Add(e);
		}
		while (i1 < elements1.Length)
		{
			elements.Add(elements1[i1]);
			i1++;
		}
		while (i2 < elements2.Length)
		{
			elements.Add(elements2[i2]);
			i2++;
		}
		var nodes = attributes.Concat(elements).ToArray();
		string value = null;
		if (elements.Count == 0)
		{
			if (!string.IsNullOrEmpty(e1.Value))
				value = e1.Value;
			if (!string.IsNullOrEmpty(e2.Value))
				value = e2.Value;
		}
		if (value != null)
			return new XElement(e1.Name, nodes, value);
		else
			return new XElement(e1.Name, nodes);
	}
	class XNameComparer : IComparer<XName>
	{
		public int Compare(XName x, XName y)
		{
			int result = string.Compare(x.Namespace.NamespaceName, y.Namespace.NamespaceName);
			if (result == 0)
				result = string.Compare(x.LocalName, y.LocalName);
			return result;
		}
	}
	class XAttributeEqualityComparer : IEqualityComparer<XAttribute>
	{
		public bool Equals(XAttribute x, XAttribute y)
		{
			return x.Name == y.Name;
		}
		public int GetHashCode(XAttribute x)
		{
			return x.Name.GetHashCode();
		}
	}
