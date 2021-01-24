    [ServiceContract, XmlSerializerFormat]
    public interface IService1
    {
        [OperationContract]
        CardTemplateDefinition SomeMethod(CardTemplateDefinition composite);
       
    }
