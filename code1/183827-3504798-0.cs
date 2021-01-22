    <system.serviceModel>
      <diagnostics>
          <messageLogging logMalformedMessages="true" logMessagesAtTransportLevel="true" />
      </diagnostics>
    </system.serviceModel>
    <system.diagnostics>
      <sources>
        <source name="System.ServiceModel" switchValue="Warning, ActivityTracing"
          propagateActivity="true">
          <listeners>
            <add type="System.Diagnostics.DefaultTraceListener" name="Default">
              <filter type="" />
            </add>
            <add name="ServiceModelTraceListener">
              <filter type="" />
            </add>
          </listeners>
        </source>
        <source name="System.ServiceModel.MessageLogging" switchValue="Warning, ActivityTracing">
          <listeners>
            <add type="System.Diagnostics.DefaultTraceListener" name="Default">
              <filter type="" />
            </add>
            <add name="ServiceModelMessageLoggingListener">
              <filter type="" />
            </add>
          </listeners>
        </source>
      </sources>
      <sharedListeners>
        <add initializeData="C:\Web_tracelog.svclog"
          type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
          name="ServiceModelTraceListener" traceOutputOptions="Timestamp">
          <filter type="" />
        </add>
        <add initializeData="C:\Web_messages.svclog"
          type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
          name="ServiceModelMessageLoggingListener" traceOutputOptions="Timestamp">
          <filter type="" />
        </add>
      </sharedListeners>
    </system.diagnostics>
