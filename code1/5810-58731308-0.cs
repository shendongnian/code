    public static class EnumExtensions
        {
            public static string GetDescription(this Enum @enum)
            {
                Type type = @enum.GetType();
                FieldInfo fi = type.GetField(@enum.ToString());
                DescriptionAttribute[] attrs =
                    fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attrs.Length > 0)
                {
                    return attrs[0].Description;
                }
                return null;
            }
        }
