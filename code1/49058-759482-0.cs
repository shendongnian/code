    static IDictionary<Type, IService> serviceRegister;
    
    public void ServerMethod(IBusinessType object)
    {
      serviceRegister[obect.GetType()].Execute(object);
    }
