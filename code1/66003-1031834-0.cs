    public static object Add(object a, object b)
    {
        var type = a.GetType();
        if (type != b.GetType())
            throw new ArgumentException("Operands are not of the same type.");
        var op = type.GetMethod("op_Addition", BindingFlags.Static | BindingFlags.Public);
        return op.Invoke(null, new object[] { a, b });
    }
