    public static T ToEnum<T>(string value, bool ignoreUpperCase)
			where T : struct, IComparable, IConvertible, IFormattable {
			Type enumType = typeof (T);
			if (!enumType.IsEnum) {
				throw new InvalidOperationException();
			}
			return (T) Enum.Parse(enumType, value, ignoreUpperCase);
    }
