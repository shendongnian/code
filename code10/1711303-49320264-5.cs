    public static class Number
    {
        private static object GetConstValue(System.Type t, string propertyName)
        {
            System.Reflection.FieldInfo pi = t.GetField(propertyName, System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                );
            return pi.GetValue(null);
        } // End Function GetConstValue 
        private static object GetMinValue(System.Type t)
        {
            return GetConstValue(t, "MinValue");
        } // End Function GetMinValue 
        private static object GetMaxValue(System.Type t)
        {
            return GetConstValue(t, "MaxValue");
        } // End Function GetMaxValue 
        private static object UnsignedToSigned(object value, System.Type t)
        {
            if (object.ReferenceEquals(t, typeof(System.UInt64)))
                return UnsignedToSigned((System.UInt64)value);
            else if (object.ReferenceEquals(t, typeof(System.UInt32)))
                return UnsignedToSigned((System.UInt32)value);
            else if (object.ReferenceEquals(t, typeof(System.UInt16)))
                return UnsignedToSigned((System.UInt16)value);
            else if (object.ReferenceEquals(t, typeof(System.Byte)))
                return UnsignedToSigned((System.Byte)value);
            throw new System.NotImplementedException($"UnsignedToSigned for type {t.Name} is not implemented.");
        }
        public static object UnsignedToSigned(object value)
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value), "Parameter cannot be NULL.");
            System.Type t = value.GetType();
            return UnsignedToSigned(value, t);
        }
        public static T UnsignedToSigned<T>(object value)
            where T:System.IComparable 
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value), "Parameter cannot be NULL.");
            System.Type t = value.GetType();
            System.Type tRet = typeof(T);
            int sizeRet = System.Runtime.InteropServices.Marshal.SizeOf(tRet);
            int sizeValue = System.Runtime.InteropServices.Marshal.SizeOf(t);
            if (sizeRet != sizeValue)
            {
                throw new System.NotSupportedException($"Type mismatch: {tRet.Name} is not the matching signed type for {t.Name}");
            }
            System.IComparable minValue = (System.IComparable)GetMinValue(t);
            
            System.IComparable minValueRet = (System.IComparable)GetMinValue(tRet);
            if (minValueRet.CompareTo(System.Convert.ChangeType(0, tRet)) == 0)
            {
                throw new System.NotSupportedException($"Type mismatch: {tRet.Name} is not a signed type.");
            }
            // If we already have an signed type
            // Type mismatch already prevented 
            if (minValue.CompareTo(System.Convert.ChangeType(0, t)) != 0)
            {
                return (T)value;
            }
            return (T)UnsignedToSigned(value, t);
        }
        private static object SignedToUnsigned(object value, System.Type t)
        {
            if (object.ReferenceEquals(t, typeof(System.Int64)))
                return SignedToUnsigned((System.Int64)value);
            else if (object.ReferenceEquals(t, typeof(System.Int32)))
                return SignedToUnsigned((System.Int32)value);
            else if (object.ReferenceEquals(t, typeof(System.Int16)))
                return SignedToUnsigned((System.Int16)value);
            else if (object.ReferenceEquals(t, typeof(System.SByte)))
                return SignedToUnsigned((System.SByte)value);
            throw new System.NotImplementedException("SignedToUnsigned for type " + t.FullName + " is not implemented.");
        }
        public static object SignedToUnsigned(object value)
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value), "Parameter cannot be NULL.");
            System.Type t = value.GetType();
            return SignedToUnsigned(value, t);
        }
        public static T SignedToUnsigned<T>(object value)
            where T : System.IComparable
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value), "Parameter cannot be NULL.");
            System.Type t = value.GetType();
            System.Type tRet = typeof(T);
            int sizeRet = System.Runtime.InteropServices.Marshal.SizeOf(tRet);
            int sizeValue = System.Runtime.InteropServices.Marshal.SizeOf(t);
            if (sizeRet != sizeValue)
            {
                throw new System.NotSupportedException($"Type mismatch: {tRet.Name} is not the matching unsigned type for {t.Name}");
            }
            System.IComparable minValue = (System.IComparable)GetMinValue(t);
            
            System.IComparable minValueRet = (System.IComparable)GetMinValue(tRet);
            if (minValueRet.CompareTo(System.Convert.ChangeType(0, tRet)) != 0)
            {
                throw new System.NotSupportedException($"Type mismatch: {tRet.Name} is not an unsigned type.");
            }
            // If we already have an unsigned type
            // Type mismatch already prevented 
            if (minValue.CompareTo(System.Convert.ChangeType(0, t)) == 0)
            {
                return (T)value;
            }
            return (T)SignedToUnsigned(value, t);
        }
        private static System.Int64 UnsignedToSigned(System.UInt64 uintValue)
        {
            return unchecked((System.Int64)uintValue + System.Int64.MinValue);
        }
        private static System.UInt64 SignedToUnsigned(System.Int64 intValue)
        {
            return unchecked((System.UInt64)(intValue - System.Int64.MinValue));
        }
        private static System.Int32 UnsignedToSigned(System.UInt32 uintValue)
        {
            return unchecked((System.Int32)uintValue + System.Int32.MinValue);
        }
        private static System.UInt32 SignedToUnsigned(System.Int32 intValue)
        {
            return unchecked((System.UInt32)(intValue - System.Int32.MinValue));
        }
        private static System.Int16 UnsignedToSigned(System.UInt16 uintValue)
        {
            return (System.Int16) unchecked((System.Int16)uintValue + System.Int16.MinValue);
        }
        private static System.UInt16 SignedToUnsigned(System.Int16 intValue)
        {
            return unchecked((System.UInt16)(intValue - System.Int16.MinValue));
        }
        private static sbyte UnsignedToSigned(byte ulongValue)
        {
            return (sbyte) unchecked((sbyte)ulongValue + sbyte.MinValue);
        }
        private static byte SignedToUnsigned(sbyte longValue)
        {
            return unchecked((byte)(longValue - sbyte.MinValue));
        }
    }
