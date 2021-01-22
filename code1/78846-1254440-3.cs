    <configuration>
    <system.serviceModel>
        <behaviors>
            <serviceBehaviors>
                <behavior name="WCFBehavior" />
            </serviceBehaviors>
        </behaviors>
        <bindings>
            <netTcpBinding>
                <binding name="tcpBinding">
                    <security>
                        <transport>
                            <extendedProtectionPolicy policyEnforcement="Never" />
                        </transport>
                    </security>
                </binding>
            </netTcpBinding>
        </bindings>
        <services>
            <service name="WCFServer.WCF">
                <endpoint address="net.tcp://localhost:1111/TcpIHostMonitor" binding="netTcpBinding"
                    bindingConfiguration="tcpBinding" name="netTcpEndpoint" contract="WCFServer.IWCFService" />
            </service>
        </services>
    </system.serviceModel>
