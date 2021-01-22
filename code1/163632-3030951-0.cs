public abstract OperationCode
{
  public byte Code {get; private set;}
  public ServerOperationCode(byte code)
  {
    Code = code
  }
}
public class ServerOperationCode: OperationCode
{
  public static LoginResponse = new ServerOperationCode(0x00);
  public static SelectionResponse = new ServerOperationCode(0x01);
  public static BlahBlahResponse = new ServerOperationCode(0x02);
  public ServerOperationCode(byte code): base(code){}
}
public class ClientOperationCode: OperationCode
{
  public static LoginRequest = new ServerOperationCode(0x00);
  public static SelectionRequest = new ServerOperationCode(0x01);
  public static BlahBlahRequest = new ServerOperationCode(0x02);
  public ClientOperationCode(byte code): base(code){}
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
