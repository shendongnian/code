    public static void WriteNameAndValue<T,TValue>(
        this TextWriter tw, T t,
        Expression<Func<T, TValue>> getter)
    {
        var memberExpression = getter.Body as MemberExpression;
        if (memberExpression == null)
            throw new ArgumentException("missing body!");
        var member = memberExpression.Member;
        tw.Write(member.Name);
        tw.Write(": ");
        if (member is FieldInfo)
        {
            tw.Write(((FieldInfo)member).GetValue(t));
        }
        else if (member is PropertyInfo)
        {
            tw.Write(((PropertyInfo)member).GetValue(t, null));
        }
    }
    
    
    public static void WriteNameAndValueLine<T,TValue>(
        this TextWriter tw, T t,
        Expression<Func<T, TValue>> getter)
    {
        
        WriteNameAndValue<T,TValue>(tw, t, getter);
        tw.WriteLine();
    }
