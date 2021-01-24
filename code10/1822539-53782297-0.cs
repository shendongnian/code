    static void Main(string[] args)
    {
        var connectionString = new FbConnectionStringBuilder
        {
            Database = "employee",
            DataSource = "sagittarius",
            ServerType = FbServerType.Default,
            UserID = "sysdba",
            Password = "masterkey",
        }.ToString();
        using (var output = File.Create(@"D:\Temp\remotebackup.fbk"))
        {
            var backup = new FbStreamingBackup();
            backup.ConnectionString = connectionString;
            backup.OutputStream = output;
            backup.Execute();
        }
        Console.ReadLine();
    }
