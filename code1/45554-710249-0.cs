            private static TypeBuilder GetTypeBuilder(string typeSigniture)
            {
                AssemblyName an = new AssemblyName("TempAssembly" + typeSigniture);
                AssemblyBuilder assemblyBuilder =
                    AppDomain.CurrentDomain.DefineDynamicAssembly(
                        an, AssemblyBuilderAccess.Run);
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
    
                TypeBuilder tb = moduleBuilder.DefineType("TempType" + typeSigniture
                                    , TypeAttributes.Public |
                                    TypeAttributes.Class |
                                    TypeAttributes.AutoClass |
                                    TypeAttributes.AnsiClass |
                                    TypeAttributes.BeforeFieldInit |
                                    TypeAttributes.AutoLayout
                                    , typeof(object), new Type[] {typeof(ISaveExtentable)});
                return tb;
            }
