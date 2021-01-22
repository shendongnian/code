    private static readonly Dictionary<Type, Func<object, byte[]>> Converters = 
            new Dictionary<Type, Func<object, byte[]>>();
    static WhateverYourTypeIsCalled()
    {
        AddConverter<string>(Encoding.UTF8.GetBytes);
        AddConverter<bool>(BitConverter.GetBytes);
        AddConverter<char>(BitConverter.GetBytes);
    }
    static void AddConverter<T>(Func<T, byte[]> converter)
    {
        Converters.Add(typeof(T), x => converter((T) x));
    }
