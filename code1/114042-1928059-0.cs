    <configuration>
      <system.diagnostics>
        <sources>
          <source name="System.ServiceModel" switchValue="Warning" propagateActivity="true" >
            <listeners>
              <add name="xml"/>
            </listeners>
          </source>
    
          <source name="myUserTraceSource" switchValue="Warning, ActivityTracing">
            <listeners>
              <add name="xml"/>
            </listeners>
          </source>
        </sources>
    
        <sharedListeners>
          <add name="xml" 
               type="System.Diagnostics.XmlWriterTraceListener" 
               initializeData="TraceLog.svclog" />
        </sharedListeners>
    
      </system.diagnostics>
    </configuration>
