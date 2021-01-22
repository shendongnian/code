       [DefaultValue(None)]
       public enum Orientation
       {
            None = -1,
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }
        public static TEnum GetDefaultValue<TEnum>() where TEnum : struct
        {
            Type t = typeof(TEnum);
            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])t.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (attributes != null &&
                attributes.Length > 0)
            {
                return (TEnum)attributes[0].Value;
            }
            else
            {
                return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(0);
            }
        }
