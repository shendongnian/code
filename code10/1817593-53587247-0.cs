    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
      </startup>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
          <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.EntityFramework, Version=8.0.13.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d"></provider>
        </providers>
      </entityFramework>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="Google.Protobuf" publicKeyToken="a7d26565bac4d604" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-3.6.1.0" newVersion="3.6.1.0" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
      <connectionStrings>
        <add name="DBEntities" connectionString="metadata=res://*/Model.PacsModel.csdl|res://*/Model.PacsModel.ssdl|res://*/Model.PacsModel.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=127.0.0.1;user id=root;password=*********;persistsecurityinfo=True;database=TestDB&quot;" providerName="System.Data.EntityClient" />
      </connectionStrings>
    </configuration>
