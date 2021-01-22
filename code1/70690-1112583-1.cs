    class BaseClass
    {
        public virtual string Method()
        {
            return string.Empty;
        }
    }
    abstract class BaseClass<T> : BaseClass where T : BaseClass<T>
    {
        protected static string[] strings;
        public override string Method()
        {
            return string.Join("  ", strings);
        }
    }
    class Subclass1 : BaseClass<Subclass1>
    {
        static Subclass1()
        {
            strings = new[] { "class1value1", "class1value2", "class1value3" };
        }
    }
    class Subclass2 : BaseClass<Subclass2>
    {
        static Subclass2()
        {
            strings = new[] { "class2value1", "class2value2", "class2value3" };
        }
    }
