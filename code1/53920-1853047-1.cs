	<!-- 
        The system.webServer section is required for running ASP.NET AJAX under Internet
        Information Services 7.0.  It is not necessary for previous version of IIS.
    -->
	<system.webServer>
		<validation validateIntegratedModeConfiguration="false" />
		<modules>
			<remove name="ScriptModule" />
			<add name="ScriptModule" preCondition="managedHandler" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
		</modules>
        <handlers accessPolicy="Read, Execute, Script">
        </handlers>
	</system.webServer>
	<runtime>
		<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
			<dependentAssembly>
				<assemblyIdentity name="System.Web.Extensions" publicKeyToken="31bf3856ad364e35" />
				<bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0" />
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.Web.Extensions.Design" publicKeyToken="31bf3856ad364e35" />
				<bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0" />
			</dependentAssembly>
		</assemblyBinding>
	</runtime>
