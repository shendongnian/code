    [ServiceContract]
    public interface IServiceA
    {
        [OperationContract]
        SecureOutput SomeSecureOperation(SecureInput input);
    }
    
    public class SecureInput
    {
        public UserCredentials Credentials { get; set; }
        public byte[] EncryptedData { get; set; }
    }
    
    public class SecureOutput
    {
        public byte[] EncryptedData { get; set; }
    }
