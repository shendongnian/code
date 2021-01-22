    static void Main()
    {
        Type t = typeof(My.Code.Here.Class1<>.Enum1);
        string s = GetCSharpName(t); // My.Code.Here.Class1<T>.Enum1<T>
    }
    public static string GetCSharpName<T>()
    {
        return GetCSharpName(typeof(T));
    }
    public static string GetCSharpName(Type type)
    {
        StringBuilder sb = new StringBuilder();
        sb.Insert(0, GetCSharpTypeName(type));
        while (type.IsNested)
        {
            type = type.DeclaringType;
            sb.Insert(0, GetCSharpTypeName(type) + ".");
            
        }
        if(!string.IsNullOrEmpty(type.Namespace)) {
            sb.Insert(0, type.Namespace + ".");
        }
        return sb.ToString();
    }
    private static string GetCSharpTypeName(Type type)
    {
        
        if (type.IsGenericTypeDefinition || type.IsGenericType)
        {
            StringBuilder sb = new StringBuilder();
            int cut = type.Name.IndexOf('`');
            sb.Append(cut > 0 ? type.Name.Substring(0, cut) : type.Name);
     
            Type[] genArgs = type.GetGenericArguments();
            if (genArgs.Length > 0)
            {
                sb.Append('<');
                for (int i = 0; i < genArgs.Length; i++)
                {
                    sb.Append(GetCSharpTypeName(genArgs[i]));
                    if (i > 0) sb.Append(',');
                }
                sb.Append('>');
            }
            return sb.ToString();
        }
        else
        {
            return type.Name;
        }
    }
