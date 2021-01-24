    [System.Runtime.Versioning.NonVersionable]
    public static implicit operator Nullable<T>(T value) {
        return new Nullable<T>(value);
    }
    
    [System.Runtime.Versioning.NonVersionable]
    public static explicit operator T(Nullable<T> value) {
        return value.Value;
    }
