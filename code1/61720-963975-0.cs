    <system.web>
      <httpModules>
        <add name="MinimizeModule" type="ClipperHouse.UrlMinimizer.MinimizeModule" />
      </httpModules>
    </system.web>
    
    
    <system.webServer>
      <validation validateIntegratedModeConfiguration="false"/>
      <modules>
        <remove name="MinimizeModule" />
        <add name="MinimizeModule" type="ClipperHouse.UrlMinimizer.MinimizeModule" 
             preCondition="managedHandler" />
      </modules>
    <system.webServer>
