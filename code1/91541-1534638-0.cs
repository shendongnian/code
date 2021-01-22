	[XmlRootAttribute("ItemList", IsNullable = false)]
	[XmlInclude(typeof(Person))]
	[XmlInclude(typeof(PersonI2))]
	[XmlInclude(typeof(Account))]
	[XmlInclude(typeof(AccountI2))]
	public class ItemList<T> : System.Xml.Serialization.IXmlSerializable
	{
		class Map : Dictionary<String, XmlSerializer> 
		{ public Map() : base(StringComparer.Ordinal) { } }
		public List<T> Items { get; set; }
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}
		private string TypeName(Type t)
		{
			String typeName = t.Name;
			foreach (XmlTypeAttribute a in t.GetCustomAttributes(typeof(XmlTypeAttribute), true))
				if (!String.IsNullOrEmpty(a.TypeName))
					typeName = a.TypeName;
			return typeName;
		}
		private Map LoadSchema()
		{
			Map map = new Map();
			foreach (XmlIncludeAttribute inc in typeof(ItemList<T>).GetCustomAttributes(typeof(XmlIncludeAttribute), true))
			{
				Type t = inc.Type;
				if (typeof(T).IsAssignableFrom(t))
					map.Add(TypeName(t), new XmlSerializer(t));
			}
			return map;
		}
		public void ReadXml(System.Xml.XmlReader reader)
		{
			Map map = LoadSchema();
			int depth = reader.Depth;
			
			List<T> items = new List<T>();
			if (!reader.IsEmptyElement && reader.Read())
			{
				while (reader.Depth > depth)
				{
					items.Add((T)map[reader.LocalName].Deserialize(reader));
				}
			}
			this.Items = items;
		}
		public void WriteXml(System.Xml.XmlWriter writer)
		{
			Map map = LoadSchema();
			foreach (T item in this.Items)
			{
				map[TypeName(item.GetType())].Serialize(writer, item);
			}
		}
	}
