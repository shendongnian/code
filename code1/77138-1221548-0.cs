    using Microsoft.SqlServer.Management.Smo;
    
    DataTable dt = SmoApplication.EnumAvailableSqlServers(true);
             string[] szSQLInstanceNames = new string[dt.Rows.Count];
             StringBuilder szSQLData = new StringBuilder();
    
             if (dt.Rows.Count > 0)
             {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                   try
                   {
                      szSQLInstanceNames[i] = dr["Name"].ToString();
                      Server oServer;
                      oServer = new Server(szSQLInstanceNames[i]);
                      if (string.IsNullOrEmpty(dr["Instance"].ToString()))
                      {
                         szSQLInstanceNames[i] = szSQLInstanceNames[i] + "\\MSSQLSERVER";
                      }
                      szSQLData.AppendLine(szSQLInstanceNames[i] + "  Version: " + oServer.Information.Version.Major + "  Service Pack: " + oServer.Information.ProductLevel + "  Edition: " + oServer.Information.Edition + "  Collation: " + oServer.Information.Collation);
                   }
                   catch (Exception Ex)
                   {
                      szSQLData.AppendLine("Exception occured while connecting to " + szSQLInstanceNames[i] + " " + Ex.Message);
                   }
    
                   i++;
                }
