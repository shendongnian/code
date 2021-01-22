    enum ObjectType { A, B, Default }
    interface IIdentifiable
    {
        ObjectType Type { get; };
    }
    class A : IIdentifiable
    {
        public ObjectType Type { get { return ObjectType.A; } }
    }
    class B : IIdentifiable
    {
        public ObjectType Type { get { return ObjectType.B; } }
    }
    void Foo(IIdentifiable o)
    {
        switch (o.Type)
        {
            case ObjectType.A:
            case ObjectType.B:
            //......
        }
    }
