    static readonly Type EF6AppConfigType = typeof(DbContext).Assembly.GetType("System.Data.Entity.Internal.AppConfig");
    static readonly PropertyInfo EF6DefaultAppConfig = EF6AppConfigType.GetProperty("DefaultInstance", BindingFlags.Public | BindingFlags.Static);
    static readonly FieldInfo EF6ConnectionStrings = EF6AppConfigType.GetField("_connectionStrings", BindingFlags.NonPublic | BindingFlags.Instance);
    static void RefreshEF6ConnectionStrings()
    {
    	EF6ConnectionStrings.SetValue(
    		EF6DefaultAppConfig.GetValue(null),
    		ConfigurationManager.ConnectionStrings
    	);
    }
