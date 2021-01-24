	public static T DeserializeObject<T>(this string source) 
    {
		if (string.IsNullOrEmpty(source))
		{
			return default(T);
		}
		try
		{
			var xmlserializer = new XmlSerializer(typeof(T));
			var stringReader = new StringReader(source);
			using (var reader = XmlReader.Create(stringReader))
			{
				var result = xmlserializer.Deserialize(reader);
				return (T)result;
			}
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred", ex);
		}
	}
