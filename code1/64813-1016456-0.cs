    public override IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    {
        IMethodReturn result = getNext()(input, getNext);
    
        if (result.Exception != null)
        {
            // do something
        }
    
        return result;
    }
