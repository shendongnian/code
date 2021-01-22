        public static bool HasFlag<TEnum>(this TEnum enumeratedType, TEnum value)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!(enumeratedType is Enum))
            {
                throw new InvalidOperationException("Struct is not an Enum.");
            }
            
            if (typeof(TEnum).GetCustomAttributes(
                typeof(FlagsAttribute), false).Length == 0)
            {
                throw new InvalidOperationException("Enum must use [Flags].");
            }
            long enumValue = enumeratedType.ToInt64(CultureInfo.InvariantCulture);
            long flagValue = value.ToInt64(CultureInfo.InvariantCulture);
            if ((enumValue & flagValue) == flagValue)
            {
                return true;
            }
            return false;
        }
