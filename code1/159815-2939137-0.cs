    public class RunTimeObject<T> where T : class
    {
        void EmitGetter(MethodBuilder methodBuilder, FieldBuilder fieldBuilder)
        {
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            ilGenerator.Emit(OpCodes.Ret);
        }
        void EmitSetter(MethodBuilder methodBuilder, FieldBuilder fieldBuilder)
        {
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Stfld, fieldBuilder);
            ilGenerator.Emit(OpCodes.Ret);
        }
        public object CreateNewObject(T obj)
        {
            AssemblyName assemblyName = new AssemblyName { Name = "assembly" };
            AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("module");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public | TypeAttributes.Class);
            foreach (var prop in obj.GetType().GetProperties())
            {
                FieldBuilder field = typeBuilder.DefineField("_" + prop.Name, typeof(string), FieldAttributes.Private);
                PropertyBuilder propertyBuilder =
                    typeBuilder.DefineProperty(prop.Name,
                                     PropertyAttributes.None,
                                     typeof(string),
                                     new Type[] { typeof(string) });
                MethodAttributes methodAttributes =
                    MethodAttributes.Public |
                    MethodAttributes.HideBySig;
                MethodBuilder methodBuilderGetter =
                    typeBuilder.DefineMethod("get_value",
                                               methodAttributes,
                                               typeof(string),
                                               Type.EmptyTypes);
                EmitGetter(methodBuilderGetter, field);
                MethodBuilder methodBuilderSetter =
                    typeBuilder.DefineMethod("set_value",
                                               methodAttributes,
                                               null,
                                               new Type[] { typeof(string) });
                EmitSetter(methodBuilderSetter, field);
                propertyBuilder.SetGetMethod(methodBuilderGetter);
                propertyBuilder.SetSetMethod(methodBuilderSetter);
            }
            Type dynamicType = typeBuilder.CreateType();
            var dynamicObject = Activator.CreateInstance(dynamicType);
            var properties = dynamicType.GetProperties();
            int count = 0;
            foreach (var item in obj.GetType().GetProperties())
                properties[count++].SetValue(dynamicObject, item.GetValue(obj, null), null);
            return dynamicObject;
        }
    }
