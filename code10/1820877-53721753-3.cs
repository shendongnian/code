	    internal static class GenericSerializator<T> where T : class
		{
			public static T LoadObjectFromFile(string fileName)
			{
				using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					var xmlSerializer = new XmlSerializer(typeof(T));
					return (T)xmlSerializer.Deserialize(file);
				}
			}
			public static void SaveObjectToFile(object value, string fileName)
			{
				var xmlSerializer = new XmlSerializer(typeof(T));
				using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
				{
					fileStream.Seek(0, SeekOrigin.End);
					using (var streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
					{
						xmlSerializer.Serialize(streamWriter, value);
					}
				}
			}
		}
		public class Test : XmlSerializableWithComments
		{
			[XmlIgnore, Description]
			public string FooCommnet { get; set; }
			public string Foo { get; set; }
			[XmlIgnore, Description]
			public string BarCommnet { get; set; }
			public string Bar { get; set; }
		}
		public class XmlSerializableWithComments : IXmlSerializable
		{
			private PropertyInfo[] Properties { get; set; }
			public XmlSerializableWithComments()
			{
				Properties = GetType().GetProperties();
			}
			public void WriteXml(XmlWriter writer)
			{
				foreach (var propertyInfo in Properties)
				{
					var value = propertyInfo.GetValue(this, null).ToString();
					if (propertyInfo.IsDefined(typeof(DescriptionAttribute), false))
					{
						writer.WriteComment(value);
					}
					else
					{
						writer.WriteElementString(propertyInfo.Name, value);
					}
				}
			}
			public XmlSchema GetSchema()
			{
				throw new NotImplementedException();
			}
			public void ReadXml(XmlReader reader)
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.EndElement)
					{
						reader.Read();
					}
					string comment = null;
					if (reader.NodeType == XmlNodeType.Comment)
					{
						comment = reader.Value;
					}
					reader.Read();
					if (reader.NodeType == XmlNodeType.Element)
					{
						var propertyName = reader.LocalName;
						PropertyInfo temp;
						if ((temp = Properties.FirstOrDefault(i => i.Name == propertyName)) != null)
						{
							reader.Read();
							temp.SetValue(this, reader.Value);
							if (!string.IsNullOrEmpty(comment))
							{
								if ((temp = Properties.FirstOrDefault(i => i.Name == propertyName + "Commnet")) != null)
								{
									temp.SetValue(this, comment);
								}
								comment = null;
							}
						}
					}
				}
			}
		}
	}
