    public IGenericTest CreateGenericTestFromType(Type tClass)
    {
       Type type = typeof(GenericTest<>).MakeGenericType(new Type[] { tClass });
       return (IGenericTest) Activator.CreateInstance(type);
    }
