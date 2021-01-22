    using System.Reflection;
    ...
    public string DoSomething(object val)
    {
        // Force the concrete type
        var typeArgs = new Type[] { val.GetType() };
        // Avoid hard-coding the overloaded method name
        string methodName = new Func<string, string>(GetName).Method.Name;
        // Use BindingFlags.NonPublic instead of Public, if protected or private
        var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
        var method = this.GetType().GetMethod(
            methodName, bindingFlags, null, typeArgs, null);
        string s = (string)method.Invoke(this, new object[] { val });
        return s;
    }
