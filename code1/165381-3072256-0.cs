    [MessageContract]
    public class CustomType
    {
    [MessageHeader(ProtectionLevel = ProtectionLevel.Sign)]
    string name;
    
    [MessageHeader(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    string secret;
