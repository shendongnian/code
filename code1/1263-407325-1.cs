    [Flags]
    public enum ErrorTypes : int {
        None = 0,
        MissingPassword = 1,
        MissingUsername = 2,
        PasswordIncorrect = 4
    }
    public static class EnumExtensions {
        
        public static T Append<T> (this System.Enum type, T value) where T : struct
        {
            return (T)(ValueType)(((int)(ValueType) type | (int)(ValueType) value));
        }
        public static T Remove<T> (this System.Enum type, T value) where T : struct
        {
            return (T)(ValueType)(((int)(ValueType)type & ~(int)(ValueType)value));
        }
        public static bool Has<T> (this System.Enum type, T value) where T : struct
        {
            return (((int)(ValueType)type & (int)(ValueType)value) == (int)(ValueType)value);
        }
    }
    ...
    //used like the following...
    
    ErrorTypes error = ErrorTypes.None;
    error = error.Append(ErrorTypes.MissingUsername);
    error = error.Append(ErrorTypes.MissingPassword);
    error = error.Remove(ErrorTypes.MissingUsername);
    //then you can check using other methods
    if (error.Has(ErrorTypes.MissingUsername)) {
        ...
    }
