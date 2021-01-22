	[Serializable]
	public class Person : ISerializable
	{
		private readonly string _name;
		public string Name
		{
			get { return _name; }
		}
		public Person(string name)
		{
			_name = name;
		}
		public string Serialize()
		{
			DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(stringBuilder))
			{
				serializer.WriteObject(writer, this);
			}
			return stringBuilder.ToString();
		}
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", _name);
		}
	}
