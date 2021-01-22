    Assert.IsTrue(resultDto.PublicInstancePropertiesEqual(expectedEntity));
    public static bool PublicInstancePropertiesEqual<T, Z>(this T self, Z to, params string[] ignore) where T : class
    {
        if (self != null && to != null)
        {
            var type = typeof(T);
            var type2 = typeof(Z);
            var ignoreList = new List<string>(ignore);
            var unequalProperties =
               from pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
               where !ignoreList.Contains(pi.Name)
               let selfValue = type.GetProperty(pi.Name).GetValue(self, null)
               let toValue = type2.GetProperty(pi.Name).GetValue(to, null)
               where selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue))
               select selfValue;
               return !unequalProperties.Any();
        }
        return self == null && to == null;
    }
