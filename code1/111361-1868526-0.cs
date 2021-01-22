    <system.data>
        <DbProviderFactories>
          <remove invariant="System.Data.SqlServerCe.3.5"></remove>
          <add name="Microsoft SQL Server Compact Data Provider" 
               invariant="System.Data.SqlServerCe.3.5" 
               description=".NET Framework Data Provider for Microsoft SQL Server Compact" 
               type="System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Version=3.5.1.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"/>
        </DbProviderFactories>
      </system.data>
