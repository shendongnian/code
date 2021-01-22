    <configuration>
      <configSections>
        <sectionGroup name="spring">
          <section name="context" type="Spring.Context.Support.ContextHandler, Spring.Core"/>
        </sectionGroup>
      </configSections>
    
      <spring>
        <context>
          <resource uri="~/Config/springContext.xml"/>
        </context>
      </spring>
    
    
      <system.web>
        <compilation debug="true">
          <assemblies>
            <add assembly="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
            <add assembly="System.Web.Abstractions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
            <add assembly="System.Web.Routing, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
            <add assembly="System.Web.Mvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
          </assemblies>
        </compilation>
    
        <pages>
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Routing" />
          </namespaces>
        </pages>
      </system.web>
    
      <system.webServer>
        <validation validateIntegratedModeConfiguration="false"/>
        <modules runAllManagedModulesForAllRequests="true"/>
      </system.webServer>
    
    </configuration>
