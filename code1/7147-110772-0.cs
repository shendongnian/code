    using System;
    using System.ComponentModel;
    static Nullable<T> ConvertFromString<T>(string value) where T:struct
    {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
        if (converter != null && !string.IsNullOrEmpty(value))
        {
            try
            {
                return (T)converter.ConvertFrom(value);
            }
            catch (Exception e) // Unfortunately Converter throws general Exception
            {
                return null;
            }
        }
        return null;
    }
    ...
    double? @double = ConvertFromString<double>("1.23");
    Console.WriteLine(@double); // prints 1.23
    int? @int = ConvertFromString<int>("100");
    Console.WriteLine(@int); // prints 100
    long? @long = ConvertFromString<int>("1.1");
    Console.WriteLine(@long.HasValue); // prints False
   
