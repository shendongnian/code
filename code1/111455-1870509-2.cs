    private T CallWebService<T>(Func<T> function)
    {
        try
        {
            return function();
        }
        catch (SoapException e)
        {
            // handle SoapException
        }
        catch (ApplicationException e)
        {
            // handle ApplicationException
        }
        // catch and handle other exceptions    
    }
    
    public ReturnType CallCreate(ParamType param)
    {
        return CallWebService<ReturnType>(() => WebService.InvokeCreate(param));
    }
    
    public ReturnType CallUpdate(ParamType param)
    {
        return CallWebService<ReturnType>(() => WebService.InvokeUpdate(param));
    }
