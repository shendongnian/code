    <configuration>
      <!-- ... -->
      <system.web.extensions>
        <scripting>
          <webServices>
            <jsonSerialization>
              <converters>
                <add name="JsonApplicationActivityReportConverter" type="YourApplicationNamespace.JsonApplicationActivityReportConverter, YourApplicationAssemblyName"/>
              </converters>
            </jsonSerialization>
          </webServices>
        </scripting>
      </system.web.extensions>
    </configuration>
