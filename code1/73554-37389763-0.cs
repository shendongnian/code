    [ServiceContract(Namespace="http://somenamespace.com/contracts")]    
        public interface ISchemaService
        {
            [OperationContract]
            [XmlSerializerFormat]
            void DoSomething(GeneratedType data);
        }
