    int x = 42;
    MyClass.Foo(x);    // displays "Non-Nullable Struct"
    int? y = 123;
    MyClass.Foo(y);    // displays "Nullable Struct"
    string z = "Test";
    MyClass.Foo(z);    // displays "Class"
    // ...
    public static class MyClass
    {
        public static void Foo<T>(T? a) where T : struct
        {
            Console.WriteLine("Nullable Struct");
        }
        public static void Foo<T>(T a)
        {
            Type t = typeof(T);
            Delegate action;
            if (!FooDelegateCache.TryGetValue(t, out action))
            {
                MethodInfo mi = t.IsValueType ? FooWithStructInfo : FooWithClassInfo;
                action = Delegate.CreateDelegate(typeof(Action<T>), mi.MakeGenericMethod(t));
                FooDelegateCache.Add(t, action);
            }
            ((Action<T>)action)(a);
        }
        private static void FooWithStruct<T>(T a) where T : struct
        {
            Console.WriteLine("Non-Nullable Struct");
        }
        private static void FooWithClass<T>(T a) where T : class
        {
            Console.WriteLine("Class");
        }
        private static readonly MethodInfo FooWithStructInfo = typeof(MyClass).GetMethod("FooWithStruct", BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly MethodInfo FooWithClassInfo = typeof(MyClass).GetMethod("FooWithClass", BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly Dictionary<Type, Delegate> FooDelegateCache = new Dictionary<Type, Delegate>();
    }
