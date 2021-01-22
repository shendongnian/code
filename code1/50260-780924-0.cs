    public static void DoStuffWithUntypedTable(ITable table)
    {
        typeof(Program).GetMethod("DoStuffWithTable")
            .MakeGenericMethod(table.Type)
            .Invoke(null, new object[] { table });
    }
