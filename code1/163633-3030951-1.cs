    public abstract class OperationCode
    {
        public byte Code { get; private set; }
        public OperationCode(byte code)
        {
            Code = code;
        }
    }
    public class ServerOperationCode : OperationCode
    {
        public static ServerOperationCode LoginResponse = new ServerOperationCode(0x00);
        public static ServerOperationCode SelectionResponse = new ServerOperationCode(0x01);
        public static ServerOperationCode BlahBlahResponse = new ServerOperationCode(0x02);
        public ServerOperationCode(byte code) : base(code) { }
    }
    public class ClientOperationCode : OperationCode
    {
        public static ClientOperationCode LoginRequest = new ClientOperationCode(0x00);
        public static ClientOperationCode SelectionRequest = new ClientOperationCode(0x01);
        public static ClientOperationCode BlahBlahRequest = new ClientOperationCode(0x02);
        public ClientOperationCode(byte code) : base(code) { }
    }
assuming packet.OperationCode return a byte, you will likely have to implement an == operator for byte. put this code into your abstract OperationCode class.
public static bool operator ==(OperationCode a, OperationCode b)
{
  return a.Code == b.Code;
}
public static bool operator !=(OperationCode a, OperationCode b)
{
  return !(a == b);
}
