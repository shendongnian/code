    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
    DatabaseSettings settings = new DatabaseSettings();
    // This maps to <databaseType> element in data config file
    DatabaseTypeData type = new DatabaseTypeData("Sql Server", "Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase, Microsoft.Practices.EnterpriseLibrary.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    settings.DatabaseTypes.Add(type);
    // This maps to <connectionString> element in data config file
    ConnectionStringData connectionString = new ConnectionStringData("localhost.EntLibQuickStarts");
    // Followings map to <parameter> elements in data config file
    ParameterData param = new ParameterData("server", "localhost");
    connectionString.Parameters.Add(param);
    param = new ParameterData("database", "EntLibQuickStarts");
    connectionString.Parameters.Add(param);
    param = new ParameterData("integrated security", "true");
    connectionString.Parameters.Add(param);
    settings.ConnectionStrings.Add(connectionString);
    // Too bad compiler gets confused InstanceData with System.Diagnostics.InstanceData.  It maps to <instance> element in data config file
    Microsoft.Practices.EnterpriseLibrary.Data.Configuration.InstanceData instance = new    Microsoft.Practices.EnterpriseLibrary.Data.Configuration.InstanceData("localhost", "Sql Server", "localhost.EntLibQuickStarts");
    settings.Instances.Add(instance);
    ConfigurationDictionary configurations = new ConfigurationDictionary();
    // This is how to tie DatabaseSettings with ConfigurationDictionary. It maps to <configurationSection name="dataConfiguration"> element in App.config file    configurations.Add("dataConfiguration", settings);
    ConfigurationContext context = ConfigurationManager.CreateContext(configurations);
    Database database = new DatabaseProviderFactory(context).CreateDatabase("localhost");
