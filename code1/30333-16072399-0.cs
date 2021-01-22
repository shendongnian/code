        public static T ToEnumValue<T>(this string enumerationDescription) where T : struct
        {
            Type type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("ToEnumValue<T>(): Must be of enum type", "T");
            foreach (object val in System.Enum.GetValues(type))
                if (val.GetDescription<T>() == enumerationDescription)
                    return (T)val;
            throw new ArgumentException("ToEnumValue<T>(): Invalid description for enum " + type.Name, "enumerationDescription");
        }
