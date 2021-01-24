    <configuration>
        <system.data>
            <DbProviderFactories>
                <remove invariant="Oracle.DataAccess.Client"></remove>
                <add name="Oracle Data Provider for .NET" invariant="Oracle.DataAccess.Client" 
                     description="Oracle Data Provider for .NET" 
                     type="Oracle.DataAccess.Client.OracleClientFactory, Oracle.DataAccess"></add>
            </DbProviderFactories>  
        </system.data>
        <runtime>
            <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
                <dependentAssembly>
                    <assemblyIdentity name="Oracle.DataAccess" />
                </dependentAssembly>
            </assemblyBinding>
        </runtime>
    </configuration>
