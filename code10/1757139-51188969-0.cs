    public static T DeserializeObject<T>(string objectXml, Encoding encoding)
		{
			XmlSerializer xs = new XmlSerializer(typeof(T));
			MemoryStream memoryStream = new MemoryStream(StringToByteArray(objectXml, encoding));
			T deserializedObject = (T)xs.Deserialize(memoryStream);
			return deserializedObject;
		}
