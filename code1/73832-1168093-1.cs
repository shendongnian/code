     <service name="SpoonSys.Api.Services"
              behaviorConfiguration="ApiLibrary.ApiBehavior" >
        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:8731/Design_Time_Addresses/ApiLibrary/" />
          </baseAddresses>
        </host>
        <endpoint 
           address="Trade" 
           binding="wsHttpBinding" 
           contract="SpoonSys.Api.Trade.ITradeService">
          <identity>
            <dns value="localhost:8731" />
          </identity>
        </endpoint>
        <endpoint 
           address="Authentication" 
           binding="wsHttpBinding" 
           contract="SpoonSys.Api.Authentication.IAuthService">
          <identity>
            <dns value="localhost:8731" />
          </identity>
        </endpoint>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
      </service>
