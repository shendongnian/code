    public delegate void ClassFieldSetter<in T, in TValue>(T target, TValue value) where T : class;
    public delegate void StructFieldSetter<T, in TValue>(ref T target, TValue value) where T : struct;
    public static class FieldSetterCreator
    {
        public static ClassFieldSetter<T, TValue> CreateClassFieldSetter<T, TValue>(FieldInfo field)
            where T : class
        {
            return CreateSetter<T, TValue, ClassFieldSetter<T, TValue>>(field);
        }
        public static StructFieldSetter<T, TValue> CreateStructFieldSetter<T, TValue>(FieldInfo field)
            where T : struct
        {
            return CreateSetter<T, TValue, StructFieldSetter<T, TValue>>(field);
        }
        private static TDelegate CreateSetter<T, TValue, TDelegate>(FieldInfo field)
        {
            return (TDelegate)(object)CreateSetter(field, typeof(T), typeof(TValue), typeof(TDelegate));
        }
        private static Delegate CreateSetter(FieldInfo field, Type instanceType, Type valueType, Type delegateType)
        {
            if (!field.DeclaringType.IsAssignableFrom(instanceType))
                throw new ArgumentException("The field is declared it different type");
            if (!field.FieldType.IsAssignableFrom(valueType))
                throw new ArgumentException("The field type is not assignable from the value");
            var paramType = instanceType.IsValueType ? instanceType.MakeByRefType() : instanceType;
            var setter = new DynamicMethod("", typeof(void),
                                            new[] { paramType, valueType },
                                            field.DeclaringType.Module, true);
            var generator = setter.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Stfld, field);
            generator.Emit(OpCodes.Ret);
            return setter.CreateDelegate(delegateType);
        }
    }
