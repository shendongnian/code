    public static T ToType<T>(this object item) where T : new() {
        var ansObj = new T();
        var ansType = typeof(T);
        foreach (var prop in item.GetType().GetPropertiesOrFields()) {
                var destField = ansType.GetMember(prop.Name, BindingFlags.Public | BindingFlags.Instance).Single();
                destField.SetValue(ansObj, prop.GetValue(item));
        }
        return ansObj;
    }
