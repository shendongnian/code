        public static string GetPropertyByValue(Type staticClass, string value)
        {
            var typeInfo = staticClass.GetProperties(BindingFlags.Static | BindingFlags.Public)
                                                    .Where(p => string.Compare(p.GetValue(null) as string, value) == 0)
                                                    .FirstOrDefault();
            return typeInfo?.Name;
        }
