    public static Type FromCSharpAlias(string alias)
    {
        bool nullable = alias.EndsWith("?");
        if (nullable)
        {
            alias = alias.Substring(0, alias.Length - 1);
        }
        Type type;
        if (!CSharpAliasToType.TryGetValue(alias, out type))
        {
             throw new ArgumentException("No such type");
        }
        return nullable ? typeof(Nullable<>).MakeGenericType(new Type[]{ type })
                        : type;
    }
