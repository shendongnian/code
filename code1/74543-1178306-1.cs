	private static string ToJson<T>(T data)
	{
		IStringSerialized s = data as IStringSerialized;
		if (s != null)
			return s.GetString();
		DataContractJsonSerializer serializer 
                    = new DataContractJsonSerializer(typeof(T));
		using (MemoryStream ms = new MemoryStream())
		{
			serializer.WriteObject(ms, data);
			return Encoding.Default.GetString(ms.ToArray());
		}
	}
