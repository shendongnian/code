    public class SkipIsDirtyProxying: IProxyGenerationHook
    {
    	public void MethodsInspected()
    	{
    	}
    
    	public void NonVirtualMemberNotification(Type type, System.Reflection.MemberInfo memberInfo)
    	{
    	}
    
    	public bool ShouldInterceptMethod(Type type, System.Reflection.MethodInfo methodInfo)
    	{
    		if (methodInfo.Name == "set_IsDirty" || methodInfo.Name == "get_IsDirty")
    		{
    			return false;
    		}
    		return true;
    	}
    }
