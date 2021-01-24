    class ResolverXml : DataContractResolver
    {
        private XmlDictionary dictionary = new XmlDictionary();
    
        public ResolverXml()
        {
        }
    
        public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (dataContractType == typeof(PropiedadTexto))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("PropiedadTexto");
                typeNamespace = dictionary.Add("JuegoMesa");
                return true;
            }
            else
            {
                return knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace);
            }
        }
    
    //    public override Type ResolveName(string typeName, string typeNamespace, DataContractResolver knownTypeResolver)
        public override Type ResolveName(string typeName, string typeNamespace, Type type, DataContractResolver knownTypeResolver)
        {
            if (typeName == "PropiedadTexto" && typeNamespace == "JuegoMesa")
            {
                return typeof(PropiedadTexto);
            }
            else
            {
                return knownTypeResolver.ResolveName(typeName, typeNamespace, type, null);
            }
        }
    }
