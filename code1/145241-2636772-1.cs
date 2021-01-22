    [ServiceContract]
    public interface IMathFunctions
    {
      [OperationContract]
      FunctionDescription[] GetFunctionList();
    
      [OperationContract]
      object RunFunction(string funcName, object[] args);
    }
    public class FunctionDescription
    {
      string Name { get; set; }
      Argument[] Arguments { get; set; }
      TypeCode ReturnType { get; set; }
    }
    
    Public class Argument
    {
      String Name { get; set; }
      TypeCode Type { get; set; }
    }
