        <system.diagnostics>
        <sources>
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
          <source name="System.ServiceModel" switchValue="Information,ActivityTracing"
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
        </sources>
        <sharedListeners>
          <add initializeData="Your_svclog_file_here"
            type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelMessageLoggingListener" traceOutputOptions="Timestamp">
            <filter type="" />
          </add>
          <add initializeData="Your_svclog_file_here"
            type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelTraceListener" traceOutputOptions="Timestamp">
            <filter type="" />
          </add>
        </sharedListeners>
        <trace autoflush="true" />
      </system.diagnostics>
