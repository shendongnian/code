    <configuration>
      <connectionStrings>
        <add name="RedisConnection" connectionString="REDIS_CONNECTION_STRING" 
              providerName="System.Data.SqlClient"/>
      </connectionStrings>
      <system.web>    
        <sessionState mode="Custom" customProvider="SessionStateStore">
          <providers>
            <add name="SessionStateStore" 
              type="Microsoft.Web.Redis.RedisSessionStateProvider" 
              connectionString="RedisConnection" />
          </providers>
        </sessionState>
      </system.web>
    <configuration>
