    <system.diagnostics>
      <sources>
        <source name="System.Security.Cryptography.Xml.SignedXml" switchName="XmlDsigLogSwitch">
          <listeners>
            <add name="logFile" />
          </listeners>
        </source>
      </sources>
      <switches>
        <add name="XmlDsigLogSwitch" value="Verbose" />
      </switches>
      <sharedListeners>
        <add name="logFile" type="System.Diagnostics.TextWriterTraceListener" initializeData="XmlDsigLog.txt"/>
      </sharedListeners>
      <trace autoflush="true">
        <listeners>
          <add name="logFile" />
        </listeners>
      </trace>
    </system.diagnostics>
