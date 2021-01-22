    // Inside Publish method ... Log the subscription
    if (this.logger != null)
    {
       Type messageType = typeof(TMessageType);
       Type callingType = GetCallingType();
       string methodName = GetCallingMethod().Name;
                    
       // Log the publication of this event
       this.logger.Log(
             string.Format("Event {0} was published by {1}.{2}()", 
                messageType.Name,
                callingType.Name,
                methodName),
          Category.Debug, 
          Priority.Low));
    }
    
    // Additional methods to add to EventService to get the calling type/class
    //
    
    /// <summary>
    /// Gets the Type that called the method or property where GetCallingType is called
    /// </summary>
    /// <returns>The class type that called</returns>
    [MethodImplAttribute(MethodImplOptions.NoInlining)]
    public static Type GetCallingType()
    {
        int skip = 2;
        MethodBase method = new StackFrame(skip, false).GetMethod();
        return method.DeclaringType;
    }
    
    /// <summary>
    /// Gets the Method that called the method or property where GetCallingMethod is called
    /// </summary>
    /// <returns>The method type that was called</returns>
    public static MethodBase GetCallingMethod()
    {
        return new StackFrame(2, false).GetMethod();
    }
