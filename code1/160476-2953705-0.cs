    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    // ...
    SqlDatabase db = new SqlDatabase("YourConnectionString");
    DbCommand cmd = db.GetStoredProcCommand("YourProcName");
    cmd.Parameters.Add(new SqlParameter("YourParamName", "param value"));
    
    using (IDataReader dr = db.ExecuteReader(cmd))
    {
        while (dr.Read())
        {
            // do something with the data
        }
    }
