            Set compilation debug="true" to insert debugging 
            symbols into the compiled page. Because this 
            affects performance, set this value to true only 
            during development.
    -->
    <compilation debug="true" targetFramework="4.0">
      <assemblies>
        <add assembly="System.Web.Mvc, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL" />
        <add assembly="System.Web.Abstractions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add assembly="System.Web.Routing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add assembly="System.Data.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
        <add assembly="System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
      </assemblies>
    </compilation>
    <!--
            The <authentication> section enables configuration 
            of the security authentication mode used by 
            ASP.NET to identify an incoming user. 
    -->
    <authentication mode="Forms">
      <forms loginUrl="~/Account/Logon" />
    </authentication>
    <membership>
      <providers>
        <clear />
        <add name="AspNetSqlMembershipProvider" type="System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="ApplicationServices" enablePasswordRetrieval="false" enablePasswordReset="true" requiresQuestionAndAnswer="false" requiresUniqueEmail="false" passwordFormat="Hashed" maxInvalidPasswordAttempts="5" minRequiredPasswordLength="6" minRequiredNonalphanumericCharacters="0" passwordAttemptWindow="10" passwordStrengthRegularExpression="" applicationName="/" />
      </providers>
    </membership>
    <profile>
      <providers>
        <clear />
        <add name="AspNetSqlProfileProvider" type="System.Web.Profile.SqlProfileProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="ApplicationServices" applicationName="/" />
      </providers>
    </profile>
    <roleManager enabled="false">
      <providers>
        <clear />
        <add connectionStringName="ApplicationServices" applicationName="/" name="AspNetSqlRoleProvider" type="System.Web.Security.SqlRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
        <add applicationName="/" name="AspNetWindowsTokenRoleProvider" type="System.Web.Security.WindowsTokenRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
      </providers>
    </roleManager>
    <customErrors mode="RemoteOnly" defaultRedirect="/Dinners/Trouble">
      <error statusCode="404" redirect="/Dinners/Confused" />
    </customErrors>
    <pages controlRenderingCompatibilityVersion="3.5" clientIDMode="AutoID">
      <namespaces>
        <add namespace="System.Web.Mvc" />
        <add namespace="System.Web.Mvc.Ajax" />
        <add namespace="System.Web.Mvc.Html" />
        <add namespace="System.Web.Routing" />
        <add namespace="System.Globalization" />
        <add namespace="System.Linq" />
        <add namespace="System.Collections.Generic" />
      </namespaces>
    </pages>
    <httpHandlers>
      <add verb="*" path="*.mvc" validate="false" type="System.Web.Mvc.MvcHttpHandler, System.Web.Mvc, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL" />
    </httpHandlers>
    <httpModules>
    </httpModules>
    <trace enabled="true" requestLimit="10" pageOutput="false" traceMode="SortByTime" localOnly="true" />
