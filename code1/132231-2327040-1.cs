    [ServiceContract]
    public interface IClientAccessPolicy
    {
        [OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
        Stream GetPolicy();
    }
