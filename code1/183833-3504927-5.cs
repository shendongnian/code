    <system.serviceModel>
        <behaviors>
            <endpointBehaviors>
                <behavior name="WebApplication2.ProdServiceAspNetAjaxBehavior">
                  <webHttp />
                </behavior>
            </endpointBehaviors>
        </behaviors>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true"
            multipleSiteBindingsEnabled="true" />
        <services>
            <service name="WebApplication2.ProdService">
                <endpoint address="" behaviorConfiguration="WebApplication2.ProdServiceAspNetAjaxBehavior"
                    binding="webHttpBinding" contract="WebApplication2.ProdService" />
            </service>
        </services>
    </system.serviceModel>
