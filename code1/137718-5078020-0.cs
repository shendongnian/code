    <connectionStrings>
        <add name="connStr" connectionString="Data Source=localhost; ..." />
    </connectionStrings>
    
    <log4net>
        <appender name="AdoNetAppender" type="log4net.Appender.AdoNetAppender">
        <connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
        <connectionStringName value="connStr" />
          ...
    </log4net>
