		......
	</connectionStrings>
	<system.web>
		<sessionState mode="InProc" timeout="20"/>
		<authorization>
			......
		</authorization>
		
		<pages>
			<namespaces>
				<add namespace="System.Data"/>
				<add namespace="System.Data.SqlClient"/>
				<add namespace="System.IO"/>
			</namespaces>
		</pages>
		<customErrors mode="Off"/>
		<compilation debug="true"/></system.web>
