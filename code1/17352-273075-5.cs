    class Car<T>
    { }
    
    interface IVehicle { }
    
    class YourCar : Car<int>, IVehicle
    { }
    
    static bool IsOfType(IVehicle param)
    {
        Type typeRef = param.GetType();
        while (typeRef != null)
        {
            if (typeRef.IsGenericType &&
                typeRef.GetGenericTypeDefinition() == typeof(Car<>))
            {
                return true;
            }
            typeRef = typeRef.BaseType;
        }
        return false;
    }
    
    static void Main(string[] args)
    {
        IVehicle test = new YourCar();
        bool x = IsOfType(test);
    }
