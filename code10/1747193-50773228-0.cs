        static IntPtr GetAddressOf(object pinned_object, string field_name)
        {
            var fi_val = pinned_object.GetType().GetField(field_name);
            var mi_all = typeof(Program).GetMethod("create_refgetter", BindingFlags.Static | BindingFlags.Public);
            var mi_generic = mi_all.MakeGenericMethod(pinned_object.GetType(), fi_val.FieldType);
            var ptr = (IntPtr) mi_generic.Invoke(null, new object[] {pinned_object, field_name });
            return ptr;
        }
        https://stackoverflow.com/a/45046664/425678
        public delegate ref U RefGetter<T, U>(T obj);
        public static IntPtr create_refgetter<T, U>(object obj,string s_field)
        {
            const BindingFlags bf = BindingFlags.NonPublic |
                                    BindingFlags.Public |
                                    BindingFlags.Instance |
                                    BindingFlags.DeclaredOnly;
            var fi = typeof(T).GetField(s_field, bf);
            if (fi == null)
                throw new MissingFieldException(typeof(T).Name, s_field);
            var s_name = "__refget_" + typeof(T).Name + "_fi_" + fi.Name;
            // workaround for using ref-return with DynamicMethod:
            //   a.) initialize with dummy return value
            var dm = new DynamicMethod(s_name, typeof(U), new[] { typeof(T) }, typeof(T), true);
            //   b.) replace with desired 'ByRef' return value
            dm.GetType().GetField("m_returnType", bf).SetValue(dm, typeof(U).MakeByRefType());
            var il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldflda, fi);
            il.Emit(OpCodes.Ret);
            RefGetter<T, U> ref_getter = (RefGetter<T, U>)dm.CreateDelegate(typeof(RefGetter<T, U>));
            unsafe
            {
                TypedReference t_ref = __makeref(ref_getter((T)obj));
                IntPtr ptr = *((IntPtr*)&t_ref);
                return ptr;
            }
        }
    }
