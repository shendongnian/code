    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="exceptionHandling" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.ExceptionHandlingSettings, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=2.0.0.0, Culture=neutral, PublicKeyToken=e99c4c62013e92da"/>    
      </configSections>
    
      <exceptionHandling>
        <exceptionPolicies>
          <add name="App Policy">
            <exceptionTypes>
              <add name="App Exception" type="System.Exception, mscorlib" postHandlingAction="None" />
            </exceptionTypes>
          </add>
          <add name="Thread Policy">
            <exceptionTypes>
              <add name="App Exception" type="System.Exception, mscorlib" postHandlingAction="None" />
            </exceptionTypes>
          </add>
        </exceptionPolicies>
      </exceptionHandling>
    </configuration>
