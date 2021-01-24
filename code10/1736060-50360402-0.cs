    <system.diagnostics>
      <sources>
        <source name="System.Net">
          <listeners>
            <add name="TraceFile"/>
            <add name="TraceConsole"/>
          </listeners>
        </source>
        <source name="System.Net.Sockets">
          <listeners>
            <add name="TraceFile"/>
          </listeners>
        </source>
      </sources>
      <sharedListeners>
        <add name="TraceFile" type="System.Diagnostics.TextWriterTraceListener" initializeData="trace.log"/>
        <add name="TraceConsole" type="System.Diagnostics.ConsoleTraceListener"/>
      </sharedListeners>
      <switches>
        <add name="System.Net" value="Verbose"/>
        <add name="System.Net.Sockets" value="Verbose"/>
      </switches>
      <trace autoflush="true"/>
    </system.diagnostics>
