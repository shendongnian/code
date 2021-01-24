    <location path="." inheritInChildApplications='false'>
      <connectionStrings>
        <add name="ApplicationDbContext" connectionString="Data Source=.;Initial Catalog=xxx;Integrated Security=True" providerName="System.Data.SqlClient" />
      </connectionStrings>
      <appSettings>
        <add key="AngularAppName" value="angularApp" />
      </appSettings>
      <system.web>
        <customErrors mode="Off" />
        <compilation debug="true" targetFramework="4.6.1" />
        <httpRuntime targetFramework="4.6.1" />
        <pages>
    	<namespaces>
    	        <add namespace="System.Web.Optimization" />
    	      </namespaces>
          <controls>
            <add assembly="Microsoft.AspNet.Web.Optimization.WebForms" namespace="Microsoft.AspNet.Web.Optimization.WebForms" tagPrefix="webopt" />
          </controls>
        </pages>
      </system.web>
      <system.codedom>
        <compilers>
          <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.8.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:default /nowarn:1659;1699;1701" />
          <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.8.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:default /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+" />
        </compilers>
      </system.codedom>
      <entityFramework>
      
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="mssqllocaldb" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
      </location>
