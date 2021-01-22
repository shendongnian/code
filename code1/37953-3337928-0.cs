    class MyClass<T>
    {
        public string Foo() { return "MyClass"; }
    }
    
    interface BaseTraits<T>
    {
        string Apply(T cls);
    }
    
    class IntTraits : BaseTraits<MyClass<int>>
    {
        public string Apply(MyClass<int> cls)
        {
            return cls.Foo() + " i";
        }
    }
    
    class DoubleTraits : BaseTraits<MyClass<double>>
    {
        public string Apply(MyClass<double> cls)
        {
            return cls.Foo() + " d";
        }
    }
    
    // Somewhere in a (static) class:
    public static IDictionary<Type, object> register;
    register = new Dictionary<Type, object>();
    register[typeof(MyClass<int>)] = new IntTraits();
    register[typeof(MyClass<double>)] = new DoubleTraits();
    
    public static string Bar<T>(this T obj)
    {
        BaseTraits<T> traits = register[typeof(T)] as BaseTraits<T>;
        return traits.Apply(obj);
    }
    
    var cls1 = new MyClass<int>();
    var cls2 = new MyClass<double>();
    
    string id = cls1.Bar();
    string dd = cls2.Bar();
