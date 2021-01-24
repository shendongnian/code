    public static class Number<T>
        where T:System.IComparable
    {
        public static bool IsSigned = MinValue.CompareTo(default(T)) == 0 ? false : true;
        public static bool IsUnsigned = MinValue.CompareTo(default(T)) == 0 ? true : false;
        private static System.Collections.Generic.Dictionary<System.Type, System.Type> MapSignedUnsigned
                = TypeMapSignedToUnsigned();
        private static System.Collections.Generic.Dictionary<System.Type, System.Type> MapUnsignedSigned
                = TypeMapUnsignedToSigned();
        private static System.Collections.Generic.Dictionary<System.Type, System.Type>
            TypeMapSignedToUnsigned()
        {
            System.Collections.Generic.Dictionary<System.Type, System.Type> dict
                = new System.Collections.Generic.Dictionary<System.Type, System.Type>();
            dict.Add(typeof(System.SByte), typeof(System.Byte));
            dict.Add(typeof(System.Int16), typeof(System.UInt16));
            dict.Add(typeof(System.Int32), typeof(System.UInt32));
            dict.Add(typeof(System.Int64), typeof(System.UInt64));
            return dict;
        }
        private static System.Collections.Generic.Dictionary<System.Type, System.Type>
            TypeMapUnsignedToSigned()
        {
            System.Collections.Generic.Dictionary<System.Type, System.Type> dict
                = new System.Collections.Generic.Dictionary<System.Type, System.Type>();
            dict.Add(typeof(System.Byte), typeof(System.SByte));
            dict.Add(typeof(System.UInt16), typeof(System.Int16));
            dict.Add(typeof(System.UInt32), typeof(System.Int32));
            dict.Add(typeof(System.UInt64), typeof(System.Int64));
            return dict;
        }
        public static T2 ToUnsigned<T2>(T input)
        {
            if (IsUnsigned)
                return (T2) (object) input;
            // T is Signed 
            // t is unsigned type for T 
            System.Type t = MapSignedUnsigned[typeof(T)];
            // TUnsigned SignedToUnsigned<TSigned, TUnsigned>(TSigned longValue)
            // return SignedToUnsigned<T, t> (input);
            System.Reflection.MethodInfo method = typeof(Number<T>).GetMethod("SignedToUnsigned");
            System.Reflection.MethodInfo genericMethod = method.MakeGenericMethod(typeof(T), t);
            return (T2) genericMethod.Invoke(null, new object[] { input });
        }
        public static T2 ToSigned<T2>(T input)
        {
            if (IsSigned)
                return (T2) (object) input;
            // T is Unsigned 
            // t is signed type for T 
            System.Type t = MapUnsignedSigned[typeof(T)];
            // TSigned UnsignedToSigned<TUnsigned, TSigned>(TUnsigned ulongValue)
            // return UnsignedToSigned<T, t> (input);
            System.Reflection.MethodInfo method = typeof(Number<T>).GetMethod("UnsignedToSigned");
            System.Reflection.MethodInfo genericMethod = method.MakeGenericMethod(typeof(T), t);
            return (T2)genericMethod.Invoke(null, new object[] { input });
        }
    }
