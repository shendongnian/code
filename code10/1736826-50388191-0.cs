    [System.Runtime.Versioning.NonVersionable]
    public static explicit operator T(Nullable<T> value) {
        return value.Value;
    }
    [System.Runtime.Versioning.NonVersionable]
    public T GetValueOrDefault(T defaultValue) {
        return hasValue ? value : defaultValue;
    }
