    <system.diagnostics>
        <sources>
            <source name="System.ServiceModel"
                      switchValue="Information, ActivityTracing"
                      propagateActivity="true">
                <listeners>
                    <add name="traceListener"
                         type="System.Diagnostics.XmlWriterTraceListener"
                         initializeData= "c:\log\Traces.svclog" />
                </listeners>
            </source>
        </sources>
    </system.diagnostics>
