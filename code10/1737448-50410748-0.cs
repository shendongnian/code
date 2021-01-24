    sealed class HelperClass
    {
        public static readonly HelperClass Instance = new HelperClass();
        public static Func<MyClass, string> CachedDelegate;
        internal string LambdaByName(MyClass x)
        {
            return x.Name;
        }
        internal string LocalFunctionByName(MyClass x)
        {
            return x.Name;
        }
    }
    void Lambda(IEnumerable<MyClass> myItems)
    {
        var lk = myItems.ToLookup(HelperClass.CachedDelegate ??
            (HelperClass.CachedDelegate =
                new Func<MyClass, string>(HelperClass.Instance.LambdaByName)));
    }
    void LocalFunction(IEnumerable<MyClass> myItems)
    {
        var lk = myItems.ToLookup(
            new Func<MyClass, string>(HelperClass.Instance.LocalFunctionByName)));
    }
