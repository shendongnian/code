    /// <summary>
    /// Overcome limitation of xml serializer 
    /// that it can't deserialize properties of classes 
    /// that inherit from IEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Xml"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public T Deserialize<T>(string Xml) where T : IEnumerable
    {
    	T functionReturnValue = default(T);
    	//let the xml serializer do the rest of the work
    	functionReturnValue = Deserialize(Xml, typeof(T));
    
    	//copy over the additional properties
    	using (XmlReader XmlReader = XmlTextReader.Create(new StringReader(Xml), new XmlReaderSettings {ValidationType = ValidationType.None,XmlResolver = null})) {
    		XmlReader.MoveToContent();
    		for (int Index = 0; Index <= XmlReader.AttributeCount - 1; Index++) {
    			XmlReader.MoveToAttribute(Index);
    			typeof(T).GetProperty(XmlReader.LocalName).SetValue(Deserialize(), XmlReader.Value, null);
    		}
    	}
    	return functionReturnValue;
    }
    public object Deserialize(string Xml, Type Type)
    {
    	object functionReturnValue = null;
    	functionReturnValue = null;
    	if (Xml == string.Empty) {
    		return null;
    	}
    	_Serializer = new XmlSerializer(Type);
    	StringReader StringReader = new StringReader(Xml);
    	functionReturnValue = Serializer.Deserialize(StringReader);
    	if (functionReturnValue is IDeserializationEvents) {
    		((IDeserializationEvents)functionReturnValue).DeserializationComplete();
    	}
    	return functionReturnValue;
    }
