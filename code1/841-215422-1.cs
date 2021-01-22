As others have noted, string is an alias for System.String. They compile to the same code, so at execution time there is no difference whatsoever. This is just one of the aliases in C#. The complete list is:
    object:  System.Object
    string:  System.String
    bool:    System.Boolean
    byte:    System.Byte
    sbyte:   System.SByte
    short:   System.Int16
    ushort:  System.UInt16
    int:     System.Int32
    uint:    System.UInt32
    long:    System.Int64
    ulong:   System.UInt64
    float:   System.Single
    double:  System.Double
    decimal: System.Decimal
    char:    System.Char
Apart from string, object, the aliases are all to value types. `decimal` is a value type, but not a primitive type in the CLR. The only primitive type which doesn't have an alias is System.IntPtr.
In the spec, the value type aliases are known as "simple types". Literals can be used for constant values of every simple type; no other value types have literal forms available. (Compare this with VB, which allows DateTime literals, and has an alias for it too.)
