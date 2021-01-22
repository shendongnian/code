       public static XmlSerializer GetSerializerFor(Type typeOfT)
        {
            if (!_serializers.ContainsKey(typeOfT))
            {
                Debug.WriteLine(string.Format("XmlSerializerFactory.GetSerializerFor(typeof({0}));", typeOfT));
                
                var types = new List<Type> { typeOfT, typeOfT.BaseType };
                foreach (var property in typeOfT.GetProperties())
                {
                    types.Add(property.PropertyType);
                }
                types.RemoveAll(t => t.ToString().StartsWith("System."));
                var xmlAttributeOverrides = new XmlAttributeOverrides();
                foreach (var type in types)
                {
                    if (xmlAttributeOverrides[type] != null) 
                        continue;
                    var xmlAttributes = new XmlAttributes
                                            {
                                                XmlType = new XmlTypeAttribute
                                                              {
                                                                  Namespace = "",
                                                                  TypeName = GetSerializationTypeName(type)
                                                              },
                                                Xmlns = false
                                            };
                    xmlAttributeOverrides.Add(type, xmlAttributes);
                }
                var newSerializer = new XmlSerializer(typeOfT, xmlAttributeOverrides);
                //var newSerializer = new XmlSerializer(typeOfT, xmlAttributeOverrides, types.ToArray(), new XmlRootAttribute(), string.Empty);
                //var newSerializer = new XmlSerializer(typeOfT, string.Empty);
                _serializers.Add(typeOfT, newSerializer);
            }
            return _serializers[typeOfT];
        }
        private static string GetSerializationTypeName(Type type)
        {
            var xmlTypeAttribute = TypeDescriptor.GetAttributes(type)
                .OfType<XmlTypeAttribute>().FirstOrDefault();
            var typeName = xmlTypeAttribute.TypeName;
            return string.IsNullOrEmpty(typeName) ? type.Name : typeName;
        }
