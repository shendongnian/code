    public delegate void delVoidMethod(params object[] args);
    
    /// <summary>
    /// Publishes an asynchronous method to the delegate collection.
    /// </summary>
    /// <param name="methodOwner">Target object owning the delegated method.</param>
    /// <param name="method">The delegated method.</param>
    /// <param name="callback">The method designated as a callback delegate.</param>
    /// <param name="ptr">The delegated method's runtime handle.</param>
    /// <returns>True if publishing was successful.</returns>
    public bool PublishAsyncMethod(object target , MethodInfo method ,
    	MethodInfo callback , out IntPtr ptr)
    {
    	try
    	{
    		ptr = method.MethodHandle.Value;
    
    		delVoidMethod dMethod = (delVoidMethod)Delegate.CreateDelegate
    			(typeof(delVoidMethod) , target , method);
    		AsyncCallback callBack = (AsyncCallback)Delegate.CreateDelegate
    			 (typeof(AsyncCallback) , target , callback);
    
    		handlers[ptr] = new DelegateStruct(dMethod , callBack);
    
    		Logger.WriteLine("Delegate : {0}.{1} -> {2}.{3} published." ,
    			method.DeclaringType.Name , method.Name ,
    			callback.DeclaringType.Name , callback.Name);
    		return true;
    	}
    	catch (ArgumentException ArgEx)
    	{
    		Logger.Write(DH_ERROR , ERR_MSG ,
    			ArgEx.Source , ArgEx.InnerException , ArgEx.Message);
    	}
    	catch (MissingMethodException BadMethEx)
    	{
    		Logger.Write(DH_ERROR , ERR_MSG ,
    			BadMethEx.Source , BadMethEx.InnerException , BadMethEx.Message);
    	}
    	catch (MethodAccessException MethAccEx)
    	{
    		Logger.Write(DH_ERROR , ERR_MSG ,
    			MethAccEx.Source , MethAccEx.InnerException , MethAccEx.Message);
    	}
    
    	ptr = IntPtr.Zero;
    
    	return false;
    }
