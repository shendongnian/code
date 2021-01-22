       <?xml version="1.0" encoding="utf-8"?>
        <configuration>
          <configSections>
            <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
            <section name="exceptionHandling" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.ExceptionHandlingSettings, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
          </configSections>
          <loggingConfiguration name="Logging Application Block" tracingEnabled="true"
            defaultCategory="General" logWarningsWhenNoCategoriesMatch="true">
            <listeners>
              <add fileName="rolling.log" footer="" formatter="Text Formatter"
                header="" rollFileExistsBehavior="Overwrite" rollInterval="None"
                rollSizeKB="500" timeStampPattern="yyyy-MM-dd" listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.RollingFlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                traceOutputOptions="None" filter="All" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.RollingFlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                name="Rolling Flat File Trace Listener" />
            </listeners>
            <formatters>
              <add template="Timestamp: {timestamp}; Message: {message}; Category: {category}; Priority: {priority}; EventId: {eventid}; Severity: {severity}; Title:{title}; Machine: {machine}; Application Domain: {appDomain}; Process Id: {processId}; Process Name: {processName}; Win32 Thread Id: {win32ThreadId}; Thread Name: {threadName}; 
     Extended Properties: {dictionary({key} - {value})}"
                type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                name="Text Formatter" />
            </formatters>
            <categorySources>
              <add switchValue="All" name="General">
                <listeners>
                  <add name="Rolling Flat File Trace Listener" />
                </listeners>
              </add>
            </categorySources>
            <specialSources>
              <allEvents switchValue="All" name="All Events" />
              <notProcessed switchValue="All" name="Unprocessed Category" />
              <errors switchValue="All" name="Logging Errors &amp; Warnings">
                <listeners>
                  <add name="Rolling Flat File Trace Listener" />
                </listeners>
              </errors>
            </specialSources>
          </loggingConfiguration>
          <exceptionHandling>
            <exceptionPolicies>
              <add name="ExPol1">
                <exceptionTypes>
                  <add type="System.ArgumentNullException, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                    postHandlingAction="None" name="ArgumentNullException">
                    <exceptionHandlers>
                      <add logCategory="General" eventId="100" severity="Error" title="Enterprise Library Exception Handling"
                        formatterType="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.TextExceptionFormatter, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                        priority="0" useDefaultLogger="false" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.LoggingExceptionHandler, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                        name="Logging Handler" />
                    </exceptionHandlers>
                  </add>
                </exceptionTypes>
              </add>
            </exceptionPolicies>
          </exceptionHandling>
        </configuration>
