        private static Dictionary<Enum, string> stringValues 
          = new Dictionary<Enum,string>();
        public static string GetStringValue(this Enum value)
        {
            if (!stringValues.ContainsKey(value))
            {
                Type type = value.GetType();
                FieldInfo fieldInfo = type.GetField(value.ToString());
                StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                    typeof(StringValueAttribute), false) as StringValueAttribute[];
                stringValues.Add(value, attribs.Length > 0 ? attribs[0].StringValue : null);
            }
            return stringValues[value];
        }
