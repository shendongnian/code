    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
      </configSections>
    
      <unity>
        <typeAliases>
          <typeAlias alias="ILogger" type="ConsoleApplication1.ILogger, ConsoleApplication1" />
          <typeAlias alias="Logger" type="ConsoleApplication1.Logger, ConsoleApplication1" />
          <typeAlias alias="TestAttribute" type="ConsoleApplication1.TestAttribute, ConsoleApplication1" />
          <typeAlias alias="TestHandler" type="ConsoleApplication1.TestHandler, ConsoleApplication1" />
          <typeAlias alias="interface" type="Microsoft.Practices.Unity.InterceptionExtension.InterfaceInterceptor, Microsoft.Practices.Unity.Interception, Version=1.2.0.0" />
        </typeAliases>
        <containers>
          <container name="ConfigureInterceptorForType">
            <extensions>
              <add type="Microsoft.Practices.Unity.InterceptionExtension.Interception, Microsoft.Practices.Unity.Interception" />
            </extensions>
            <extensionConfig>
              <add name="interception" type="Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationElement, Microsoft.Practices.Unity.Interception.Configuration">
                <interceptors>
                  <interceptor type="interface">
                    <key type="ILogger"/>
                  </interceptor>
                </interceptors>
              </add>
            </extensionConfig>
            <types>
              <type type="ILogger" mapTo="Logger" />
            </types>
          </container>
        </containers>
      </unity>
    </configuration>
