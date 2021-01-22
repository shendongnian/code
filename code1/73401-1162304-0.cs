        public static class ColorInfo
        {
            private static readonly PropertyInfo[] PropertiesInfo;
            static ColorInfo()
            {
                PropertiesInfo = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            }
            public static bool TryGetKnownColorFromString(string colorName, out KnownColor knowColor)
            {
                if (String.IsNullOrEmpty(colorName))//if wrong color name
                {
                    knowColor = KnownColor.ActiveBorder;
                    return false;
                }
                try
                {
                    foreach (PropertyInfo property in PropertiesInfo)
                    {
                        if (property.Name.Equals(colorName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            knowColor = ((Color)property.GetValue(null, null)).ToKnownColor();
                            return true;
                        }
                    }
                }
                catch (Exception exc)
                {
                    //catch GetValue & Equals methods exceptions
                    if (!(exc is ArgumentException || exc is TargetException ||
                        exc is TargetParameterCountException ||
                        exc is MethodAccessException ||
                        exc is TargetInvocationException))
                    {
                        throw exc; 
                    }
                }
                knowColor = KnownColor.ActiveBorder;
                return false;
            }
        }
