    enum DbType {
        Unspecified,
        SqlServer
    }
    DbType t;
    int i = 0;
    Console.WriteLine(t == i);
    Console.WriteLine(i == default(DbType));
