    <system.diagnostics>
    <sources>
      <source name="System.ServiceModel.MessageLogging">
        <listeners>
          <add name="messages" type="System.Diagnostics.XmlWriterTraceListener" initializeData="messages.svclog" />
         </listeners>
      </source>
    </sources>
