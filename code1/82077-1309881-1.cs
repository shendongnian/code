    [ServiceContract]
    public interface IServiceA
    {
        [OperationContract]
        SecureOutput SomeSecureOperation(SecureInput input);
        [OperationContract]
        byte[] GetPublicKey();
    }
    public class SecureInput
    {
        public UserCredentials Credentials { get; set; }
        public byte[] UserPublicKey { get; set; }
        public byte[] EncryptedData { get; set; }
    }
    
    public class SecureOutput
    {
        public byte[] EncryptedData { get; set; }
    }
