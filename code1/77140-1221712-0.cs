    using System;
    using System.Collections.Generic;
    using System.Data.Sql;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace Info.Data.Engine.SQLServer
    {
      public static class SQLServerHelper
      {
        public static List<String> EnumerateServers()
        {
          var instances = SqlDataSourceEnumerator.Instance.GetDataSources();
          if ((instances == null) || (instances.Rows.Count < 1)) return null;
    
          var result = new List<String>();
          foreach (DataRow instance in instances.Rows)
          {
            var serverName = instance["ServerName"].ToString();
            var instanceName = instance["InstanceName"].ToString();
            result.Add(String.IsNullOrEmpty(instanceName) ? serverName : String.Format(@"{0}\{1}", serverName, instanceName));
          }
          return result;
        }
    
        public static List<String> EnumerateDatabases(String connectionString)
        {
          try
          {
            using (var connection = new SqlConnection(connectionString))
            {
              connection.Open();
              var databases = connection.GetSchema("Databases");
              connection.Close();
              if ((databases == null) || (databases.Rows.Count < 1)) return null;
    
              var result = new List<String>();
              foreach (DataRow database in databases.Rows)
              {
                result.Add(database["database_name"].ToString());
              }
              return result;
            }
          }
          catch
          {
            return null;
          }
        }
      }
    }
