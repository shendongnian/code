    public static T DeepClone<T>(this T objectToClone) where T: BaseClass
	{
		BinaryFormatter bFormatter = new BinaryFormatter();
		MemoryStream stream = new MemoryStream();
		bFormatter.Serialize(stream, objectToClone);
		stream.Seek(0, SeekOrigin.Begin);
		T clonedObject = (T)bFormatter.Deserialize(stream);
		return clonedObject;
	}
