    class AnonymousType0
    {
        public MyClass A { get; set; }
        public othertype B { get; set; }
    }
    bool WhereFunc0( MyClass a )
    {
        return a.SomeProp > 10;
    }
    AnonymousType0 SelectResultFunc0( MyClass a )
    {
        AnonymousType0 result = new AnonymousType0();
        result.A = a;
        result.B = a.GetB();
    }
    ...
    list
        .Where( new Func<MyClass,bool>( WhereFunc0 ) )
        .Select( new Func<MyClass,AnonymousType0>( SelectResultFunc0 ) );
