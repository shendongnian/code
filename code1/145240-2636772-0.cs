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
      TypeCode[] ArgumentTypes { get; set; }
      TypeCode[] ReturnType { get; set; }
    }
