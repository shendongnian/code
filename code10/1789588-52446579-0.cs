       TheObjectClass theObject = new TheObjectClass();
        Type objType = typeof(TheObjectClass);
        object obj = objType.GetTypeInfo().GetDeclaredMethod("GetInt").Invoke(theObject, null);
        object val  = obj.GetType().GetProperty("Result").GetValue(obj);
        Type t = val.GetType();
        Console.WriteLine(t.Name);
