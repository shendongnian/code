    using System.Collections.Generic;
    using System.Reflection;
    /// <summary>Comparison class.</summary>
    public static class Compare
    {
        /// <summary>Compare the public instance properties. Uses deep comparison.</summary>
        /// <param name="self">The reference object.</param>
        /// <param name="to">The object to compare.</param>
        /// <param name="ignore">Ignore property with name.</param>
        /// <typeparam name="T">Type of objects.</typeparam>
        /// <returns><see cref="bool">True</see> if both objects are equal, else <see cref="bool">false</see>.</returns>
        public static bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                var type = self.GetType();
                var ignoreList = new List<string>(ignore);
                foreach (var pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (ignoreList.Contains(pi.Name))
                    {
                        continue;
                    }
                    var selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                    var toValue = type.GetProperty(pi.Name).GetValue(to, null);
                    if (pi.PropertyType.IsClass && !pi.PropertyType.Module.ScopeName.Equals("CommonLanguageRuntimeLibrary"))
                    {
                        // Check of "CommonLanguageRuntimeLibrary" is needed because string is also a class
                        if (PublicInstancePropertiesEqual(selfValue, toValue, ignore))
                        {
                            continue;
                        }
                        return false;
                    }
                    if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return self == to;
        }
    }
