    var sql = @"BEGIN :refcursor1 := mypackage.myfunction(:param1) ; end;";
    using(OracleConnection con = new OracleConnection("<connection string>"))
    using(OracleCommand com = new OracleCommand())
    {
         com.Connection = con;
         con.Open();
         com.Parameters.Add(":refcursor1", OracleDbType.RefCursor, ParameterDirection.Output);
         com.Parameters.Add(":param1", "param");
         com.CommandText = sql;
         com.CommandType = CommandType.Text;
         com.ExecuteNonQuery();
         OracleRefCursor curr = (OracleRefCursor)com.Parameters[0].Value;
         using(OracleDataReader dr = curr.GetDataReader())
         {
             if(dr.Read())
             {
                 var value1 = dr.GetString(0);
                 var value2 = dr.GetString(1);
             }
         }
     }
