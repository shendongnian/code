    public enum OperationCode
    {
     LoginResponse,
     SelectionResponse,
     BlahBlahResponse
    }
    public interface IOperationCodeTranslator {
     public OperationCode GetOperationCode(byte inputcode);
     }
    public class ServerOperationCode : IOperationCodeTranslator
    {
      public OperationCode GetOperationCode(byte inputcode) {
        switch(inputcode) {
           case 0x00: return OperationCode.LoginResponse;
          [...]
        } 
    }
