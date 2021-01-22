    public int GetValue(IHasValue obj)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
        Type t = obj.GetType();
        PropertyInfo pi = t.GetProperty("Value",
            BindingFlags.Instance | BindingFlags.Public);
        MethodInfo getMethod = pi.GetGetMethod();
        var exbAttributes = (ExceptionBehaviorAttribute[])
            getMethod.GetCustomAttributes(typeof(ExceptionBehaviorAttribute), false);
        try
        {
            return obj.Value;
        }
        catch (Exception ex)
        {
            var matchAttribute = exbAttributes.FirstOrDefault(a =>
                a.ExceptionType.IsAssignableFrom(ex.GetType()));
            if ((matchAttribute != null) &&
                (matchAttribute.Action == ExceptionAction.ReturnDefault))
            {
                return default(int);
            }
            throw;
        }
    }
