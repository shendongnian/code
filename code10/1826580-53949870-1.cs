    // Convert any object to another Type by copying over common properties or fields
    public static T ToType<T>(this object obj) where T : new() {
        var ansObj = new T();
        var ansFields = typeof(T).GetPropertiesOrFields().ToDictionary(pf => pf.Name);
        foreach (var prop in obj.GetType().GetPropertiesOrFields())
            if (ansFields.TryGetValue(prop.Name, out var destpf))
                destpf.SetValue(ansObj, prop.GetValue(obj));
        return ansObj;
    }
