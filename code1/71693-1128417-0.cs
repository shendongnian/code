    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    internal sealed class StaticInterfaceAttribute : Attribute
    {
        private readonly Type interfaceType;
        // This is a positional argument
        public StaticInterfaceAttribute(Type interfaceType)
        {
            this.interfaceType = interfaceType;
        }
        public Type InterfaceType
        {
            get
            {
                return this.interfaceType;
            }
        }
        public static void VerifyStaticInterfaces()
        {
            Assembly assembly = typeof(StaticInterfaceAttribute).Assembly;
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                foreach (StaticInterfaceAttribute staticInterface in t.GetCustomAttributes(typeof(StaticInterfaceAttribute), false))
                {
                    VerifyImplementation(t, staticInterface);
                }
            }
        }
        private static void VerifyInterface(Type type, Type interfaceType)
        {
            // TODO: throw TypeLoadException? if `type` does not implement the members of `interfaceType` as public static members.
        }
    }
    internal interface IMaxLength
    {
        uint MaxLength
        {
            get;
        }
    }
    [StaticInterface(typeof(IMaxLength))]
    internal class ComplexString
    {
        public static uint MaxLength
        {
            get
            {
                return 0;
            }
        }
    }
