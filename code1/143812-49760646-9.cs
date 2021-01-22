    public void RunCommand(string sql, OracleParameter param)
    {
        OracleConnection oraConn = null;
        OracleCommand oraCmd = null;
        try
        {
            string connString = GetConnString();
            oraConn = OracleConnection(connString);
            using (oraConn)
            {
                if (OraConnection.State == ConnectionState.Open)
                    OraConnection.Close();
                OraConnection.Open();
                oraCmd = new OracleCommand(strSQL, oraConnection);
                // Add your OracleParameter
                if (param != null)
                    OraCommand.Parameters.Add(param);
                // Execute the command
                OraCommand.ExecuteNonQuery();
            }
        }
        catch (OracleException err)
        {
           // handle exception 
        }
        finally
        {
           OraConnction.Close();
        }
    }
    private string GetConnString()
    {
        string host = System.Configuration.ConfigurationManager.AppSettings["host"].ToString();
        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();
        string serviceName = System.Configuration.ConfigurationManager.AppSettings["svcName"].ToString();
        string schemaName = System.Configuration.ConfigurationManager.AppSettings["schemaName"].ToString();
        string pword = System.Configuration.ConfigurationManager.AppSettings["pword"].ToString(); // hopefully encrypted
        if (String.IsNullOrEmpty(host) || String.IsNullOrEmpty(port) || String.IsNullOrEmpty(serviceName) || String.IsNullOrEmpty(schemaName) || String.IsNullOrEmpty(pword))
        {
            return "Missing Param";
        }
        else
        {
            pword = decodePassword(pword);  // decrypt here
            return String.Format(
               "Data Source=(DESCRIPTION =(ADDRESS = ( PROTOCOL = TCP)(HOST = {2})(PORT = {3}))(CONNECT_DATA =(SID = {4})));User Id={0};Password{1};",
               user,
               pword,
               host,
               port,
               serviceName
               );
        }
    }
