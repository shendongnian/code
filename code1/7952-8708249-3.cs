    public void DeepCopy<T>(ref T object2Copy, ref T objectCopy)
    {
    	using (var stream = new MemoryStream())
    	{
    		var serializer = new XS.XmlSerializer(typeof(T));
    
    		serializer.Serialize(stream, object2Copy);
    		stream.Position = 0;
    		objectCopy = (T)serializer.Deserialize(stream);
    	}
    }
