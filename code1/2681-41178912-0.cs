    public static string ToEnumString<TEnum>(this int enumValue)
            {
                var enumString = enumValue.ToString();
                if (Enum.IsDefined(typeof(TEnum), enumValue))
                {
                    enumString = ((TEnum) Enum.ToObject(typeof (TEnum), enumValue)).ToString();
                }
                return enumString;
            }
