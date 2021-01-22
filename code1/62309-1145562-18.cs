    using System;
    public T CastObject<T>(object input) {   
        return (T) input;   
    }
    public T ConvertObject<T>(object input) {
        return (T) Convert.ChangeType(input, typeof(T));
    }
