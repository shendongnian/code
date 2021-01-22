    public class NVelocityEventHandler : IInvalidReferenceEventHandler, IMethodExceptionEventHandler
    {
    		#region IInvalidReferenceEventHandler Members
    
    		public object InvalidGetMethod(NVelocity.Context.IContext context, string reference, object object_Renamed, string property, NVelocity.Util.Introspection.Info info)
    		{
    			return "InvalidGetMethod:" + reference;
    		}
    
    		public object InvalidMethod(NVelocity.Context.IContext context, string reference, object object_Renamed, string method, NVelocity.Util.Introspection.Info info)
    		{
    			return "InvalidMethod:" + reference;
    		}
    
    		public bool InvalidSetMethod(NVelocity.Context.IContext context, string leftreference, string rightreference, NVelocity.Util.Introspection.Info info)
    		{
    			return true;
    		}
    
    		#endregion
    
    		#region IMethodExceptionEventHandler Members
    
    		object IMethodExceptionEventHandler.MethodException(Type claz, string method, Exception e)
    		{
    			return "MethodException:" + method;
    		}
    
    		#endregion 
    }
