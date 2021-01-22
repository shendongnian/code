    private static readonly Dictionary<Type, bool> _flagEnums = new Dictionary<Type, bool>();
    public static bool ValidateEnumValue<T>(T value) where T : Enum
    {
        // Check if a simple value is defined in the enum.
        Type enumType = typeof(T);
        bool valid = Enum.IsDefined(enumType, value);
        if (!valid)
        {
            // For enums decorated with the FlagsAttribute, allow sets of flags.
            if (!_flagEnums.TryGetValue(enumType, out bool isFlag))
            {
                isFlag = enumType.GetCustomAttributes(typeof(FlagsAttribute), false)?.Any() == true;
                _flagEnums.Add(enumType, isFlag);
            }
            if (isFlag)
            {
                long mask = 0;
                foreach (object definedValue in Enum.GetValues(enumType))
                    mask |= Convert.ToInt64(definedValue);
                long longValue = Convert.ToInt64(value);
                valid = (mask & longValue) == longValue;
            }
        }
        return valid;
    }
