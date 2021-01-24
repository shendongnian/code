    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <system.data>
        <DbProviderFactories>      
          <remove invariant="System.Data.CData.MySQL"></remove>
          <add name="CData ADO.NET Provider for MySQL 2018"
               invariant="System.Data.CData.MySQL" 
               description="CData ADO.NET Provider for MySQL 2018" 
               type="System.Data.CData.MySQL.MySQLProviderFactory, System.Data.CData.MySQL>
          </add>          
        </DbProviderFactories>
      </system.data>
    </configuration>
