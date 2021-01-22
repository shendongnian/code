    private void InvokeAction (Action<TData> action, data)
    {
        try
        {
            action(data);
        }
        catch (EndpointNotFoundException enfe)
        {
            .... unified handling here
        }
        catch (OtherExceptionType oet)
        {
        }
    }
