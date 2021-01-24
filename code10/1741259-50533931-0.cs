      <system.diagnostics>
        <sources>
          <source name="System.Net" maxdatasize="102400" tracemode="includehex">
            <listeners>
              <add name="System.Net" />
            </listeners>
          </source>
        </sources>
        <switches>
          <add name="System.Net" value="Verbose" />
        </switches>
        <sharedListeners>
          <add name="System.Net" type="System.Diagnostics.TextWriterTraceListener" initializeData="c:\somewhere...\networkErr.log" />
        </sharedListeners>
      </system.diagnostics>
