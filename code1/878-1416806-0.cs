    public static class EnumExtensions
    {
        public static bool ContainsFlag(this Enum source, Enum flag)
        {
            var sourceValue = ToUInt64(source);
            var flagValue = ToUInt64(flag);
            return (sourceValue & flagValue) == flagValue;
        }
        public static bool ContainsAnyFlag(this Enum source, params Enum[] flags)
        {
            var sourceValue = ToUInt64(source);
            foreach (var flag in flags)
            {
                var flagValue = ToUInt64(flag);
                if ((sourceValue & flagValue) == flagValue)
                {
                    return true;
                }
            }
            return false;
        }
        // found in the Enum class as an internal method
        private static ulong ToUInt64(object value)
        {
            switch (Convert.GetTypeCode(value))
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return (ulong)Convert.ToInt64(value, CultureInfo.InvariantCulture);
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
            }
            throw new InvalidOperationException("Unknown enum type.");
        }
    }
