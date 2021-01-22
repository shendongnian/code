    public DataContractSerializer (Type type,
			IEnumerable<Type> knownTypes,
			int maxObjectsInGraph,
			bool ignoreExtensionDataObject,
			**bool preserveObjectReferences,**
			IDataContractSurrogate dataContractSurrogate)
			: this (type, knownTypes)
		{
			Initialize (maxObjectsInGraph,
				ignoreExtensionDataObject,
				**preserveObjectReferences,**
				dataContractSurrogate);
		}
		public DataContractSerializer (Type type,
			string rootName,
			string rootNamespace,
			IEnumerable<Type> knownTypes,
			int maxObjectsInGraph,
			bool ignoreExtensionDataObject,
			**bool preserveObjectReferences,**
			IDataContractSurrogate dataContractSurrogate)
			: this (type, rootName, rootNamespace, knownTypes)
		{
			Initialize (maxObjectsInGraph,
				ignoreExtensionDataObject,
				**preserveObjectReferences,**
				dataContractSurrogate);
		}
		public DataContractSerializer (Type type,
			XmlDictionaryString rootName,
			XmlDictionaryString rootNamespace,
			IEnumerable<Type> knownTypes,
			int maxObjectsInGraph,
			bool ignoreExtensionDataObject,
			**bool preserveObjectReferences,**
			IDataContractSurrogate dataContractSurrogate)
			: this (type, rootName, rootNamespace, knownTypes)
		{
			Initialize (maxObjectsInGraph,
				ignoreExtensionDataObject,
				**preserveObjectReferences,**
				dataContractSurrogate);
		}
