    static void Main()
    {
        Pet a = _MakeObject(typeof(Dog));
        Pet b = _MakeObject(typeof(Cat));
    }
    
    private static Pet _MakeObject(Type type)
    {
        ConstructorInfo info = type.GetConstructor(new Type[0]);
        return (Pet)info?.Invoke(null);
    }
