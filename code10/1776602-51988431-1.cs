    public static DbProviderFactory GetProviderFactory(DbConnection connection)
    {
        DbProviderFactory providerFactory = null;
        Type connectionType = connection.GetType();
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        // Check for DbConnection.DbProviderFactory
        PropertyInfo providerFactoryInfo = connectionType.GetProperty("DbProviderFactory", flags);
        if (providerFactoryInfo != null)
            providerFactory = (DbProviderFactory)providerFactoryInfo.GetValue(connection, null);
        // Check for DbConnection.ConnectionFactory.ProviderFactory
        if (providerFactory == null)
        {
            PropertyInfo connectionFactoryInfo = connectionType.GetProperty("ConnectionFactory", flags);
            object connectionFactory = connectionFactoryInfo.GetValue(connection, null);
            providerFactoryInfo = connectionFactory.GetType().GetProperty("ProviderFactory", flags);
            providerFactory = (DbProviderFactory)providerFactoryInfo.GetValue(connectionFactory, null);
        }
        // No match
        if (providerFactory == null)
            throw new InvalidOperationException("ProviderFactory not found for connection");
        return providerFactory;
    }
