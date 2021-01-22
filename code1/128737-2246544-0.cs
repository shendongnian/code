    private ServiceImplementation _implementation = new ServiceImplementation();
    public string Get(Parameter param)
    {
        List<string> myList = new List<string>();
        //some service specific business rules implemented here
        return implementation.Get(param);
    }
