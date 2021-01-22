    public static bool ValidateEnumValue<T>(T value) where T : Enum
    {
        // Check if a simple value is defined in the enum.
        Type enumType = typeof(T);
        bool valid = Enum.IsDefined(enumType, value);
        // For enums decorated with the FlagsAttribute, allow sets of flags.
        if (!valid && enumType.GetCustomAttributes(typeof(FlagsAttribute), false)?.Any() == true)
        {
            long mask = 0;
            foreach (object definedValue in Enum.GetValues(enumType))
                mask |= Convert.ToInt64(definedValue);
            long longValue = Convert.ToInt64(value);
            valid = (mask & longValue) == longValue;
        }
        return valid;
    }
