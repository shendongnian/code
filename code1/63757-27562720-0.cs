    [AttributeUsage(AttributeTargets.Method)]
    public class WebGetText : Attribute, IOperationBehavior
    {
    
    	public void Validate(OperationDescription operationDescription)
    	{
    	}
    
    	public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    	{
    		dispatchOperation.Formatter = new Formatter();
    	}
    
    	public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    	{
    	}
    
    	public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    	{
    	}
    }
    
    public class Formatter : IDispatchMessageFormatter
    {
    
    	public void DeserializeRequest(Message message, object[] parameters)
    	{
    		Debug.WriteLine("DeserializeRequest");
    	}
    
    	public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    	{
    		IEnumerable<object> cl = (IEnumerable<object>)result;
    		StringBuilder csvdata = new StringBuilder();
    
    
    		foreach (object userVariableClass in cl) {
    			Type type = userVariableClass.GetType();
    			PropertyInfo[] fields = type.GetProperties();
    
    			//            Dim header As String = String.Join(";", fields.Select(Function(f) f.Name + ": " + f.GetValue(userVariableClass, Nothing).ToString()).ToArray())
    			//            csvdata.AppendLine("")
    			//            csvdata.AppendLine(header)
    			csvdata.AppendLine(ToCsvFields(";", fields, userVariableClass));
    			csvdata.AppendLine("");
    			csvdata.AppendLine("=====EOF=====");
    			csvdata.AppendLine("");
    		}
    		Message msg = WebOperationContext.Current.CreateTextResponse(csvdata.ToString());
    		return msg;
    	}
    
    	public static string ToCsvFields(string separator, PropertyInfo[] fields, object o)
    	{
    		StringBuilder linie = new StringBuilder();
    
    		foreach (PropertyInfo f in fields) {
    			if (linie.Length > 0) {
    			}
    
    			object x = f.GetValue(o, null);
    
    			if (x != null) {
    				linie.AppendLine(f.Name + ": " + x.ToString());
    			} else {
    				linie.AppendLine(f.Name + ": Nothing");
    			}
    		}
    
    		return linie.ToString();
    	}
    }
