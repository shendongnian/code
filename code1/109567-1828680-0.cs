    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    class CustomAttribute : Attribute
    {}
    abstract class Base
    {
        protected Base()
        {
            this.Attributes = Attribute.GetCustomAttributes(this.GetType(), typeof(CustomAttribute))
                .Cast<CustomAttribute>()
                .ToArray();
        }
        protected CustomAttribute[] Attributes { get; private set; }
    }
    [Custom]
    [Custom]
    [Custom]
    class Derived : Base
    {
        static void Main()
        {
            var derived = new Derived();
            var attribute = derived.Attributes[2];
        }
    }
