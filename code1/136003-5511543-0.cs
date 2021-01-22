    using System;
    using System.ServiceModel.Description;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    /// <summary>
    /// Summary description for ReferencePreservingDataContractSerializerOperationBehavior
    /// </summary>
    public class ReferencePreservingDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
        public ReferencePreservingDataContractSerializerOperationBehavior(OperationDescription operation) : base(operation)
        {
        }
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes, this.MaxItemsInObjectGraph, this.IgnoreExtensionDataObject, true, this.DataContractSurrogate);
        }
        public override XmlObjectSerializer CreateSerializer(Type type, System.Xml.XmlDictionaryString name, System.Xml.XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes, this.MaxItemsInObjectGraph, this.IgnoreExtensionDataObject, true, this.DataContractSurrogate);
        }
    }
