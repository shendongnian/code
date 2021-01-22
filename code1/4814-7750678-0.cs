        public static object GetEnumDescriptions(Type enumType)
        {
            var list = new List<KeyValuePair<Enum, string>>();
            foreach (Enum value in Enum.GetValues(enumType))
            {
                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
                if (attribute != null)
                {
                    description = (attribute as DescriptionAttribute).Description;
                }
                list.Add(new KeyValuePair<Enum, string>(value, description));
            }
            return list;
        }
