       public static MethodInfo GetOrderByMethod(Type elementType, Type sortKeyType)
        {
            MethodInfo mi = typeof(Program).GetMethod("GetOrderByMethod", Type.EmptyTypes);
            var getOrderByMethod = mi.MakeGenericMethod(new Type[] { elementType, sortKeyType });
            return getOrderByMethod.Invoke(null, new object[] { }) as MethodInfo;
        }
