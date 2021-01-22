    public static class ExtensionMethods
    {
        public static void CopyPropertiesTo<T, U>(this T source, U dest)
        {
            var plistsource = from prop1 in typeof(T).GetProperties() where prop1.CanRead select prop;
            var plistdest = from prop2 in typeof(U).GetProperties() where prop2.CanWrite select prop;
            foreach (PropertyInfo destprop in plistdest)
            {
                var sourceprops = plistsource.Where((p) => p.Name == destprop.Name &&
                  destprop.PropertyType.IsAssignableFrom(p.GetType()));
                foreach (PropertyInfo sourceprop in sourceprops)
                { // should only be one
                    destprop.SetValue(dest, sourceprop.GetValue(source, null), null);
                }
            }
        }
    }
