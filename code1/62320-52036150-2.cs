    private static Enum GetEnum(Type type, int value)
        {
            if (type.IsEnum)
                if (Enum.IsDefined(type, value))
                {
                    return (Enum)Enum.ToObject(type, value);
                }
            return null;
        }
