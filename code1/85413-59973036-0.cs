    public static class TypeNameExtensions
    {
        public static bool TryGetNameAlias(this Type t, out string alias)
            => (alias = TypeAliases[(int)Type.GetTypeCode(t)]) != null;
        private static readonly string[] TypeAliases = {
            "void",     // 0
            null,       // 1 (any other type)
            "DBNull",   // 2
            "bool",     // 3
            "char",     // 4
            "sbyte",    // 5
            "byte",     // 6
            "short",    // 7
            "ushort",   // 8
            "int",      // 9
            "uint",     // 10
            "long",     // 11
            "ulong",    // 12
            "float",    // 13
            "double",   // 14
            "decimal",  // 15
            null,       // 16 (DateTime)
            null,       // 17 (-undefined- presumably TimeSpan in some pre-1.0 C# alpha)
            "string",   // 18
        };
    }
