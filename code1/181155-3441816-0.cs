    var settings = ConfigurationManager.ConnectionStrings[ 0 ];
    
    var fi = typeof( ConfigurationElement ).GetField( "_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic );
    
    fi.SetValue(settings, false);
    
    settings.ConnectionString = "Data Source=Something";
