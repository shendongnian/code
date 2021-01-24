        <system.diagnostics>
        <sources>
          <source name="System.ServiceModel.MessageLogging">
            <listeners>
              <add type="System.Diagnostics.XmlWriterTraceListener" name="xmlLog" initializeData="myLogs.svclog"/>
            </listeners>
          </source>
        </sources>
      </system.diagnostics>
      <system.serviceModel>
        <diagnostics>
          <messageLogging logEntireMessage="true" logMessagesAtServiceLevel="true" logMessagesAtTransportLevel="false" />
        </diagnostics>
      </system.serviceModel>
