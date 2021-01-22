    static void Main()
    {
        Pet a = _MakeObject(typeof(Dog), 5);
        Pet b = _MakeObject(typeof(Cat), 7);
    }
    
    private static Pet _MakeObject(Type type, int age)
    {
        ConstructorInfo info = type.GetConstructor(new Type[1] { typeof(int) });
        return (Pet)info?.Invoke(new object[1] { age });
    }
