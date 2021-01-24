    class PropertyTypeBase { }
    class PropertyTypeA : PropertyTypeBase { }
    class Base<T> where T : PropertyTypeBase
    {
        public T Property { get; }
    }
    class Foo :  Base<PropertyTypeA>
    {
        public Foo()
        {
            PropertyTypeBase x = Property;
            PropertyTypeA a = Property;
        }
    }
