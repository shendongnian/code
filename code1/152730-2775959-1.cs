    public void MethodToTest(string parameter)
    {
        IResponse x = ResponseBuilder.BuildResponse(parameter);
       
        if (x != null)
        {
            x.Success();
        }
    }
