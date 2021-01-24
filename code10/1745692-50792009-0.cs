    <system.diagnostics>
        <trace autoflush="true" indentsize="0">
            <listeners>
                <add name="myAppInsightsListener"
                    type="Microsoft.ApplicationInsights.TraceListener.ApplicationInsightsTraceListener, Microsoft.ApplicationInsights.TraceListener"/>
            </listeners>
        </trace>
    </system.diagnostics>
