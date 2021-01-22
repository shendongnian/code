    static public MyClass Clone(MyClass myClass)
	{
		MyClass clone;
		XmlSerializer ser = new XmlSerializer(typeof(MyClass), _xmlAttributeOverrides);
		using (var ms = new MemoryStream())
		{
			ser.Serialize(ms, myClass);
			ms.Position = 0;
			clone = (MyClass)ser.Deserialize(ms);
		}
		return clone;
	}
