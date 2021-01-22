	public struct Child
	{
		public string name;
		public Child(string name)
		{
			this.name = name;
		}
	}
	public class Parent
	{
		public List<Child> childs = new List<Child>();
		public static List<Parent> ReadParentsFromXml(string fileName)
		{
			List<Parent> parents = new List<Parent>();
			System.Xml.XmlTextReader doc = new System.Xml.XmlTextReader(fileName);
			Parent element = new Parent();
			while (doc.Read())
			{
				switch (doc.Name)
				{
					case "parents":
						if (doc.NodeType == System.Xml.XmlNodeType.EndElement)
						{
							parents.Add(element);
							element = new Parent();
						}
						break;
					case "child":
						if(doc.NodeType != System.Xml.XmlNodeType.EndElement)
							element.childs.Add(new Child(doc.GetAttribute(0)));
						break;
				}
			}
			return parents;
		}
	}
