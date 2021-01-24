    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
        <configSections>
            <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Unity.Configuration"/>
        </configSections>
        <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
            <assembly name="UnityExample" />
            <namespace name="UnityExample.Service" />
            <containers>
                <container name="Service">
                    <register type="IProductService" mapTo="ProductService"/>
                </container>
            </containers>
        </unity>
        <startup>
            <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
        </startup>
        <runtime>
            <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
                <dependentAssembly>
                    <assemblyIdentity name="Unity.Configuration" publicKeyToken="6d32ff45e0ccc69f" culture="neutral" />
                    <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
                </dependentAssembly>
            </assemblyBinding>
        </runtime>
    </configuration>
