    class PropertyBase<T>
    {
        public static Type GetMyType() { return typeof (T); }
    }
    // the base class is actually a generic specialized by the derived class type
    class ConcreteProperty : PropertyBase<ConcreteProperty> { /* more code here */ }
    // t == typeof(ConcreteProperty)
    var t = ConcreteProperty.GetMyType();
