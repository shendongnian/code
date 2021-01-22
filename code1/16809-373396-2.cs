        public static MethodInfo GetSelectMethod(Type t)
        {
            MethodInfo mi = typeof(Program).GetMethod("GetSelectMethod", Type.EmptyTypes);
            var getSelectMethod = mi.MakeGenericMethod(new Type[] { t });
            return getSelectMethod.Invoke(null, new object[] { } ) as MethodInfo;
        }
