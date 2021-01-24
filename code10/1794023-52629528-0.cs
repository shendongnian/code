    <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="mssqllocaldb" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
        <interceptors>
          <interceptor type="System.Data.Entity.Infrastructure.Interception.DatabaseLogger, EntityFramework">
            <parameters>
              <parameter value="C:\inetpub\wwwroot\App_Data\LogOutput.txt"/>
              <parameter value="true" type="System.Boolean"/>
            </parameters>
          </interceptor>
        </interceptors>
      </entityFramework>
