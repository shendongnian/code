    <entityFramework>
      <defaultConnectionFactory type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.EntityFramework, Version=8.0.11.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
      <providers>
        <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.EntityFramework, Version=8.0.11.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d"/>
      </providers>
    </entityFramework>
    <system.data>
      <DbProviderFactories>
        <remove invariant="MySql.Data.MySqlClient" />
        <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=8.0.11.0, Culture=neutral, PublicKeyToken=C5687FC88969C44D" />
      </DbProviderFactories>
    </system.data>
