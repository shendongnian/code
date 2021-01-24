	public static partial class XNodeExtensions
	{
		public static XElement GetOrAddElement(this XContainer container, XName name)
		{
			if (container == null || name == null)
				throw new ArgumentNullException();
			var element = container.Element(name);
			if (element == null)
				container.Add(element = new XElement(name));
			return element;
		}
	}
