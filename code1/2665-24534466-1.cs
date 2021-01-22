        public static string GetDescriptionValue<T>(this T source)
        {
            FieldInfo fileInfo = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fileInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);            
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return source.ToString();
            }
        }
