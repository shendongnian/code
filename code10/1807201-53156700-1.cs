    private string GetConnectionString()
    {
      var connectStringValue = ConfigurationManager.ConnectionStrings["MyObjectContext"].ConnectionString;
      var entityBuilder = new EntityConnectionStringBuilder(connectStringValue);
      var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
      var providerBuilder = factory.CreateConnectionStringBuilder();
    
      if (providerBuilder == null)
            return entityBuilder.ToString();
    
      providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
      providerBuilder.Add("Password", "**yourpassword**");
    
      entityBuilder.ProviderConnectionString = providerBuilder.ToString();
    
      return entityBuilder.ToString();
    }
