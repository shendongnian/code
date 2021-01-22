      <system.diagnostics>
        <sources>
          <source name="System.ServiceModel" 
                  switchValue="Information" 
                  propagateActivity="true">
            <listeners>
              <add name="ServiceModelTraceListener" 
                   type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" 
                   initializeData="wcf-traces.svclog"/>
            </listeners>
          </source>
        </sources>
      </system.diagnostics>
