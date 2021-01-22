    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [SecurityPermission(SecurityAction.LinkDemand, 
        Flags = SecurityPermissionFlag.Infrastructure)] // per FxCop
    public override IMessage Invoke(IMessage msg)
    {
        IMethodCallMessage msgMethodCall = msg as IMethodCallMessage;
        Debug.Assert(msgMethodCall != null); // should not be null - research Invoke if this trips. KWB 2009.05.28
        
        // The MethodCallMessageWrapper
        // provides read/write access to the method 
        // call arguments. 
        MethodCallMessageWrapper mc =
            new MethodCallMessageWrapper(msgMethodCall);
        
        // This is the reflected method base of the called method. 
        MethodInfo mi = (MethodInfo)mc.MethodBase;
    
        IMessage retval = null;
    
        // Pass the call to the method and get our return value
        string profileName = ProfileClassName + "." + mi.Name;
        
        using (ProfileManager.Start(profileName))
        {
            IMessage myReturnMessage =
               RemotingServices.ExecuteMessage(_target, msgMethodCall);
    
            retval = myReturnMessage;
        }
    
        return retval;
    }
