    print("<system.diagnostics>
        <sources>
            <source name="System.ServiceModel" switchValue="Verbose,ActivityTracing"
                propagateActivity="true">
                <listeners>
                    <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                        <filter type="" />
                    </add>
                    <add name="NewListener">
                        <filter type="" />
                    </add>
                </listeners>
            </source>
        </sources>
        <sharedListeners>
            <add initializeData="C:\App_tracelog.svclog"
                type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                name="NewListener" traceOutputOptions="LogicalOperationStack, DateTime, Timestamp, ProcessId, ThreadId, Callstack">
                <filter type="" />
            </add>
        </sharedListeners>
    </system.diagnostics>");
