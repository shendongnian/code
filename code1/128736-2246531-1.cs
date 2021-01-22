    //Convert:
    public string Get(Parameter param)
    {
        List<string> myList = new List<string>();
        //some service specific business rules implemented here
        return myList.ToString();
    }
    
    //Into:
    public string Get(Parameter param)
    {
        var serviceFor = new ModelService<MyModel>();
        return serviceFor.ExecuteGet(param);
    }
