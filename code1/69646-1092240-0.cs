    <system.diagnostics>
        <trace autoflush="true">
            <listeners>
            </listeners>
        </trace>
        <sources>
            <source name="System.ServiceModel"
                    switchValue="Information, ActivityTracing"
                    propagateActivity="true">
                <listeners>
                    <add name="sdt"
                         type="System.Diagnostics.XmlWriterTraceListener"
                         initializeData= "WcfDetailTrace.svclog" />
                </listeners>
            </source>
        </sources>
    </system.diagnostics>
