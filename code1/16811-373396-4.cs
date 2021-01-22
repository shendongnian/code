       public static MethodInfo GetOrderByMethod(Type elementType, Type sortKeyType)
        {
            MethodInfo mi = typeof(Program).GetMethod("GetOrderByMethod", Type.EmptyTypes);
            var getSelectMethod = mi.MakeGenericMethod(new Type[] { elementType, sortKeyType });
            return getSelectMethod.Invoke(null, new object[] { }) as MethodInfo;
        }
