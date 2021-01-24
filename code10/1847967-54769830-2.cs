    public static void PrintInfo(Type t)
    {
        Console.WriteLine($"Information for {t}");
        foreach (string name in t.GetEnumNames())
        {
            MemberInfo member = t.GetMember(name).Single();
            FieldAttribute attr =
                (FieldAttribute)member.GetCustomAttributes(typeof(FieldAttribute), false)
                          .SingleOrDefault();
            string text = attr.MyMethod();
            Console.WriteLine(name + " -> " + text);
        }
    }
