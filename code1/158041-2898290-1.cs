    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <configSections>
            <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
        </configSections>
        <loggingConfiguration name="" tracingEnabled="true" defaultCategory="Category">
            <listeners>
                <add name="Rolling Flat File Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.RollingFlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.RollingFlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    formatter="Text Formatter" rollInterval="Day" rollSizeKB="2000" />
            </listeners>
            <formatters>
                <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    template="Timestamp: {timestamp}{newline}
