    public static string ConnectionString { get; private set; }
    
    static MyClass()
    {
    	ConnectionString = @"Data Source=" + myLibrary.common.GetExeDir() + @"\Database\db.sdf;";
    }
