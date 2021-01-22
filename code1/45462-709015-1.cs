    // the types of the constructor parameters, in order
    // use an empty Type[] array if the constructor takes no parameters
    Type[] paramTypes = new Type[] { typeof(string), typeof(int) };
    // the values of the constructor parameters, in order
    // use an empty object[] array if the constructor takes no parameters
    object[] paramValues = new object[] { "test", 42 };
    TheTypeYouWantToInstantiate instance =
        Construct<TheTypeYouWantToInstantiate>(paramTypes, paramValues);
    // ...
    public static T Construct<T>(Type[] paramTypes, object[] paramValues)
    {
        Type t = typeof(T);
        ConstructorInfo ci = t.GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null, paramTypes, null);
        return (T)ci.Invoke(paramValues);
    }
