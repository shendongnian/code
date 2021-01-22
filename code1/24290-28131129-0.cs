    /// <summary>
    /// Overcome limitation of xml serializer 
    /// that it can't deserialize properties of classes 
    /// that inherit from IEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Xml"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static T Deserialize<T>(string Xml) where T : IEnumerable
    {
    	T functionReturnValue = default(T);
    	//create a fake object that is not a list and populate that
    	Emit.TypeBuilder TypeBuilder = Reflection.GetTypeBuilder();
    	Emit.ConstructorBuilder ConstructorBuilder = TypeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
    	foreach (PropertyInfo PropertyInfo in Reflection.PersistableProperties(typeof(T))) {
    		Reflection.CreateProperty(TypeBuilder, PropertyInfo.Name, PropertyInfo.PropertyType);
    	}
    	Type DynamicType = TypeBuilder.CreateType;
    	object DynamicObject = Activator.CreateInstance(DynamicType);
    	using (XmlReader XmlReader = XmlTextReader.Create(new StringReader(Xml), new XmlReaderSettings {ValidationType = ValidationType.None,XmlResolver = null})) {
    		XmlReader.MoveToContent();
    		foreach (PropertyInfo PropertyInfo in DynamicType.GetProperties) {
    			PropertyInfo.SetValue(DynamicObject, XmlReader.GetAttribute(PropertyInfo.Name), null);
    		}
    
    		//let the xml serializer do the rest of the work
    		functionReturnValue = Deserialize(Xml, typeof(T));
    
    		//write back the properties from the dynamic object
    		foreach (PropertyInfo PropertyInfo in DynamicType.GetProperties) {
    			functionReturnValue.GetType.GetProperty(PropertyInfo.Name).SetValue(Deserialize(), PropertyInfo.GetValue(DynamicObject, null), null);
    		}
    
    	}
    	return functionReturnValue;
    
    }
