    <configuration>
      <configSections>
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null" />
        <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null" />
      </configSections>
    <dataConfiguration defaultDatabase="DEV" />
    <connectionStrings>
        <add name="DEV" connectionString="Database=xxx;Server=xxx;Trusted_Connection=True" providerName="System.Data.SqlClient" />
        <add name="LIVE" connectionString="Database=xxx;Server=xxx;Trusted_Connection=True" providerName="System.Data.SqlClient" />
    </connectionStrings>...
