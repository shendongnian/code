	public static class XmlExtensions
	{
		public static XElement ParseFragment(string xmlFragment)
		{
			using (var reader = new StringReader("<a>").Concat(new StringReader(xmlFragment)).Concat(new StringReader("</a>")))
			{
				return XElement.Load(reader);
			}
		}
	}
