    public object GetDefaultValue(Type t) {
        if (t.IsValueType && Nullable.GetUnderlyingType(t) == null) {
            return Activator.CreateInstance(t);
        } else {
            return null;
        }
    }
