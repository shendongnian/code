    using EntLibContrib.Data.OdpNet;
    using Microsoft.Practices.EnterpriseLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    // replace to the right namespace
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    
    
    public Database GetDatabase(string name)
    {
         UMiami.MedResearch.Core.ConnectionString str = this.Retrieve(name);
         if (str != null)
         {
             if (str.ProviderType == "SQL Server")
             {
                 return new SqlDatabase(str.Value);
             }
             if (str.ProviderType == "Oracle")
             {
                 return new OracleDatabase(str.Value);
             }
         }
         throw new Exception("Connection string was not found.");
    }
