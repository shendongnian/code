    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <system.web>
        <compilation debug="true" />
      </system.web>
      <!-- When deploying the service library project, the content of the config file must be added to the host's 
      app.config file. System.Configuration does not support config files for libraries. -->
      <system.serviceModel>
        <services>
          <service behaviorConfiguration="ApiLibrary.ApiBehavior"
            name="SpoonSys.ApiLibrary.Trade.TradeService">
            <endpoint address="" binding="wsHttpBinding" contract="SpoonSys.Api.Trade.ITradeService">
              <identity>
                <dns value="localhost:8731" />
              </identity>
            </endpoint>
            <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:8731/Design_Time_Addresses/Trade/" />
              </baseAddresses>
            </host>
          </service>
          <service behaviorConfiguration="ApiLibrary.ApiBehavior"
            name="SpoonSys.Api.Authentication.AuthService">
            <endpoint address="" binding="wsHttpBinding" contract="SpoonSys.ApiLibrary.Authentication.IAuthService">
              <identity>
                <dns value="localhost:8731" />
              </identity>
            </endpoint>
            <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
            <host>
              <baseAddresses>
                <add baseAddress="localhost:8731/Design_Time_Addresses/Authentication/" />
              </baseAddresses>
            </host>
          </service>
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior name="ApiLibrary.ApiBehavior">
              <!-- To avoid disclosing metadata information, 
              set the value below to false and remove the metadata endpoint above before deployment -->
              <serviceMetadata httpGetEnabled="True"/>
              <!-- To receive exception details in faults for debugging purposes, 
              set the value below to true.  Set to false before deployment 
              to avoid disclosing exception information -->
              <serviceDebug includeExceptionDetailInFaults="True" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
    </configuration>
