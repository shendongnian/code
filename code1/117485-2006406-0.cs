    public enum OracleVersion
    {
        Oracle9,
        Oracle10,
        Oracle0
    };
    
    private OracleVersion GetOracleVersion()
    {
        RegistryKey rgkLM = Registry.LocalMachine;
        RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\ALL_HOMES");
    
        /* 
    	 * 10g Installationen don't have an ALL_HOMES key
         * Try to find HOME at SOFTWARE\ORACLE\
     	 * 10g homes start with KEY_
         */
        string[] okeys = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE").GetSubKeyNames();
        foreach (string okey in okeys)
        {
            if (okey.StartsWith("KEY_"))
                return OracleVersion.Oracle10;
        }
    
        if (rgkAllHome != null)
        {
            string strLastHome = "";
            object objLastHome = rgkAllHome.GetValue("LAST_HOME");
            strLastHome = objLastHome.ToString();
            RegistryKey rgkActualHome = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\HOME" + strLastHome);
            string strOraHome = "";
            object objOraHome = rgkActualHome.GetValue("ORACLE_HOME");
            string strOracleHome = strOraHome = objOraHome.ToString();
            return OracleVersion.Oracle9;
        }
        return OracleVersion.Oracle0;
    }
    
    private string GetOracleHome()
    {
        RegistryKey rgkLM = Registry.LocalMachine;
        RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\ALL_HOMES");
        OracleVersion ov = this.GetOracleVersion();
    
        switch(ov)
        {
            case OracleVersion.Oracle10:
                {
                    string[] okeys = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE").GetSubKeyNames();
                    foreach (string okey in okeys)
                    {
                        if (okey.StartsWith("KEY_"))
    					{
                            return rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\" + okey).GetValue("ORACLE_HOME") as string;
    					}
                    }
                    throw new Exception("No Oracle Home found");
                }
            case OracleVersion.Oracle9:
                {
                    string strLastHome = "";
                    object objLastHome = rgkAllHome.GetValue("LAST_HOME");
                    strLastHome = objLastHome.ToString();
                    RegistryKey rgkActualHome = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\HOME" + strLastHome);
                    string strOraHome = "";
                    object objOraHome = rgkActualHome.GetValue("ORACLE_HOME");
                    string strOracleHome = strOraHome = objOraHome.ToString();
                    return strOraHome;
                }
            default:
                {
                    throw new Exception("No supported Oracle Installation found");
                }
        }
    }
    
    public string GetTNSNAMESORAFilePath()
    {
        string strOracleHome = GetOracleHome();
        if (strOracleHome != "")
        {
            string strTNSNAMESORAFilePath = strOracleHome + @"\NETWORK\ADMIN\TNSNAMES.ORA";
            if (File.Exists(strTNSNAMESORAFilePath))
            {
                return strTNSNAMESORAFilePath;
            }
            else
            {
                strTNSNAMESORAFilePath = strOracleHome + @"\NET80\ADMIN\TNSNAMES.ORA";
                if (File.Exists(strTNSNAMESORAFilePath))
                {
                    return strTNSNAMESORAFilePath;
                }
                else
                {
                    throw new SystemException("Could not find tnsnames.ora");
                }
            }
        }
        else
        {
            throw new SystemException("Could not determine ORAHOME");
        }
    }
