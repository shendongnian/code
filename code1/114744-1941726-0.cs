	public class MyDeserializer : System.Xml.Serialization.XmlSerializer
	{
		protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader)
		{
			Foo obj = (Foo)base.Deserialize(reader);
			return Foo.Get(obj.id);
		}
	}
