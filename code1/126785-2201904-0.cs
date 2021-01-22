    public static class SerializationExtensions
    {
    	public static XElement Serialize(this object source)
    	{
    		try
    		{
    			var serializer = XmlSerializerFactory.GetSerializerFor(source.GetType());
    			var xdoc = new XDocument();
    			using (var writer = xdoc.CreateWriter())
    			{
    				serializer.Serialize(writer, source, new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") }));
    			}
    
    			return (xdoc.Document != null) ? xdoc.Document.Root : new XElement("Error", "Document Missing");
    		}
    		catch (Exception x)
    		{
    			return new XElement("Error", x.ToString());
    		}
    	}
    
    	public static T Deserialize<T>(this XElement source) where T : class
    	{
    		try
    		{
    			var serializer = XmlSerializerFactory.GetSerializerFor(typeof(T));
    
    			return (T)serializer.Deserialize(source.CreateReader());
    		}
    		catch //(Exception x)
    		{
    			return null;
    		}
    	}
    }
    public static class XmlSerializerFactory
    {
    	private static Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();
    
    	public static XmlSerializer GetSerializerFor(Type typeOfT)
    	{
    		if (!serializers.ContainsKey(typeOfT))
    		{
    			System.Diagnostics.Debug.WriteLine(string.Format("XmlSerializerFactory.GetSerializerFor(typeof({0}));", typeOfT));
    
    			var newSerializer = new XmlSerializer(typeOfT);
    			serializers.Add(typeOfT, newSerializer);
    		}
    
    		return serializers[typeOfT];
    	}
    }
