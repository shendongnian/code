	public class CustomDataContractSerializerBehavior : DataContractSerializerOperationBehavior
    {
        public CustomDataContractSerializerBehavior(OperationDescription operation)
            : base(operation)
        {
        }
        public CustomDataContractSerializerBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns,
            IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, knownTypes, Int32.MaxValue, false, true, new CustomDataContractSurrogate());
        }
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name,
            XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, knownTypes, Int32.MaxValue, false, true, new CustomDataContractSurrogate());
        }
    }
