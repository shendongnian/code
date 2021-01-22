    <system.data>
      <DbProviderFactories>
        <remove invariant="Oracle.ManagedDataAccess.Client" />
        <!-- If any should be in the machine.config -->
        <add name="Oracle Data Provider for .NET" invariant="Oracle.ManagedDataAccess.Client" description="Oracle Data Provider for .NET" type="Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess, Version=4.121.1.0, Culture=neutral" />
      </DbProviderFactories>
    </system.data>
    <connectionStrings>
      <clear />
      <add name="OracleContext" providerName="Oracle.ManagedDataAccess.Client" connectionString="DATA SOURCE=<IP_ADDRESS>:1521/XE;PASSWORD=<PASSWORD>;USER ID=<USER_ID>;Connection Timeout=600;Validate Connection=true" />
    </connectionStrings>
