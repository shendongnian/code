    class Program
    {
        static Assembly ass;
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Test"), AssemblyBuilderAccess.Run);
            var moduleBuilder = assembly.DefineDynamicModule("Test");
            var baseTypeBuilder = moduleBuilder.DefineType("Base", TypeAttributes.Public, typeof(Object));
            var derivedTypeBuilder = moduleBuilder.DefineType("Derived", TypeAttributes.Public);
            derivedTypeBuilder.SetParent(baseTypeBuilder);
            baseTypeBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(XmlIncludeAttribute).GetConstructor(new[] { typeof(Type) }), new[] { derivedTypeBuilder }));
            var baseType = baseTypeBuilder.CreateType();
            var derivedType = derivedTypeBuilder.CreateType();
            ass = baseType.Assembly;
            var attribute = baseType.GetCustomAttribute<XmlIncludeAttribute>();
            Console.WriteLine(attribute.Type.FullName);
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return ass;
        }
    }
