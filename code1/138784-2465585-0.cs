    <system.serviceModel>
        <services>
            <service
                name="MyNamespace.MyService"
                behaviorConfiguration="returnFaults">
                <endpoint
                    address=""
                    behaviorConfiguration="RESTBehavior"
                    binding="webHttpBinding"
                    contract="MyNamespace.IMyGenericService">
                </endpoint>
            </service>
        </services>
        <behaviors>
            <endpointBehaviors>
               <behavior name="RESTBehavior">
                  <webHttp/>
               </behavior>
            </endpointBehaviors>
            <serviceBehaviors>
                <behavior name="returnFaults">
                    <serviceDebug includeExceptionDetailInFaults="true"/>
                </behavior>
            </serviceBehaviors>
        </behaviors>
    </system.serviceModel>
