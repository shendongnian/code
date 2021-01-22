    static string GetFullName(Type t)
    {
        if (!t.IsGenericType)
            return t.Name;
        StringBuilder sb=new StringBuilder();
        sb.Append(t.Name.Substring(0, t.Name.LastIndexOf("`")));
        sb.Append(t.GetGenericArguments().Aggregate("<",
            delegate(string aggregate,Type type)
                {
                    return aggregate + (aggregate == "<" ? "" : ",") + GetFullName(type);
                }  
            ));
        sb.Append(">");
        return sb.ToString();
    }
