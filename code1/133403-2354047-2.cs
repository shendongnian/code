    public class dynamic_data_serializer<T>
    {
        public T create(object obj)
        {
            T inst = Activator.CreateInstance<T>();
            var bindings = obj as IDictionary<string, object>;
            foreach (var pair in bindings)
            {
                setters[pair.Key](inst, pair.Value);
            }
            return inst;
        }
        private static readonly Dictionary<string, Action<T, object>> setters;
        static dynamic_data_serializer()
        {
            setters = new Dictionary<string, Action<T, object>>(StringComparer.Ordinal);
            foreach (PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
                setters.Add(prop.Name, CreateForMember(prop));
            }
            foreach (FieldInfo field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance)) {
                setters.Add(field.Name, CreateForMember(field));
            }
        }
        static Action<T, object> CreateForMember(MemberInfo member)
        {
            bool isField;
            Type type;
            switch (member.MemberType) {
                case MemberTypes.Property:
                    isField = false;
                    type = ((PropertyInfo)member).PropertyType;
                    break;
                case MemberTypes.Field:
                    isField = true;
                    type = ((FieldInfo)member).FieldType;
                    break;
                default:
                    throw new NotSupportedException();
            }
            DynamicMethod method = new DynamicMethod("__set_" + member.Name, null, new Type[] { typeof(T), typeof(object) });
            ILGenerator il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            if(type != typeof(object)) {
                il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
            }
            if (isField) {il.Emit(OpCodes.Stfld, (FieldInfo)member);}
            else { il.EmitCall(OpCodes.Callvirt, ((PropertyInfo)member).GetSetMethod(), null);  }
    
            il.Emit(OpCodes.Ret);
            return (Action<T, object>)method.CreateDelegate(typeof(Action<T, object>));
        }
    }
