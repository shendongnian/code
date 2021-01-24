    public static void PrintInfo(Type t)
    {
        Console.WriteLine($"Information for {t}");
        var names = t.GetEnumNames();
        var pairs =
            from name in names
            let member = t.GetMember(name).Single()
            let attr = (FieldAttribute)member.GetCustomAttributes(typeof(FieldAttribute), false)
                          .SingleOrDefault()
            let text = attr.MyMethod()
            select (name, text);
        foreach (var (name, text) in pairs)
            Console.WriteLine($"{name} -> {text}");
    }
