    public static void DoStuffWithUntypedTable(object table)
    {
        Type type = table.GetType();
        while (type != typeof(object))
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition()
                  == typeof(Table<>))
            {
                typeof(Program).GetMethod("DoStuffWithTable")
                    .MakeGenericMethod(type.GetGenericArguments()[0])
                    .Invoke(null, new object[] { table });
                return;
            }
            type = type.BaseType;
        }
        throw new ArgumentException("Not a Table<T> or subclass");
    }
