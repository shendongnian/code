    public static class SerializableObjectBaseExtensions
    {
        static readonly Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();
        static readonly object padlock = new object();
        public static XmlSerializer GetSerializer<TSerializable>(TSerializable obj) where TSerializable : SerializableObjectBase, new()
        {
            return GetSerializer(obj == null ? typeof(TSerializable) : obj.GetType());
        }
        public static XmlSerializer GetSerializer<TSerializable>() where TSerializable : SerializableObjectBase, new()
        {
            return GetSerializer(typeof(TSerializable));
        }
        static XmlSerializer GetSerializer(Type serializableType)
        {
            lock (padlock)
            {
                XmlSerializer serializer;
                if (!serializers.TryGetValue(serializableType, out serializer))
                    serializer = serializers[serializableType] = CreateSerializer(serializableType);
                return serializer;
            }
        }
        static XmlSerializer CreateSerializer(Type serializableType)
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            for (var declaringType = serializableType; declaringType != null && declaringType != typeof(object); declaringType = declaringType.BaseType)
            {
                // check whether each property has the custom attribute
                foreach (PropertyInfo property in declaringType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                {
                    XmlAttributes attrbs = new XmlAttributes();
                    // if it has the attribute, tell the overrides to serialize this property
                    // property.IsDefined is faster than actually creating and returning the attribute
                    if (property.IsDefined(typeof(GenericSerializableAttribute), true))
                    {
                        Console.WriteLine("Adding " + property.Name + "");
                        attrbs.XmlElements.Add(new XmlElementAttribute(property.Name));
                    }
                    else
                    {
                        // otherwise, ignore the property
                        Console.WriteLine("Ignoring " + property.Name + "");
                        attrbs.XmlIgnore = true;
                    }
                    // add this property to the list of overrides
                    overrides.Add(declaringType, property.Name, attrbs);
                }
            }
            // create the serializer
            return new XmlSerializer(serializableType, overrides);
        }
    }
