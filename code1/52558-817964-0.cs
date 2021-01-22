    public override IEnumerable<Type> SupportedTypes
    { 
        get
        {
            var list = new List<Type>{ typeof(Foo), typeof(Bar)...};
            return list.AsReadOnly();
        }
    }
