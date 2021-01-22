    static bool IsDefaultValue<T>(T input)
    {
        return Object.Equals(input, default(T));
    }
Note: you can't use == for equality using generic type T.
