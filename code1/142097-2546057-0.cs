    interface IMyInterface
    {
       void A();
       int  B();
    }
    
    class One : IMyInterface
    {
       ...
       implement A and B
       ...
    }
    Type elType = Type.GetType(obj);
    Type genType = typeof(GenericType<>).MakeGenericType(elType);
    IMyInterface obj = (IMyInterface)Activator.CreateInstance(genType);
    obj.A();
